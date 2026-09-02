// Cross-tab authentication synchronizer and cookie validator for Blazor Interactive Server
window.authSync = (function () {
    const CHANNEL_NAME = 'pms_auth_sync_channel';
    const STORAGE_KEY = 'pms_auth_sync_event';

    let broadcastChannel = null;
    let isInitialized = false;

    if (typeof BroadcastChannel !== 'undefined') {
        broadcastChannel = new BroadcastChannel(CHANNEL_NAME);
    }

    function handleLogoutEvent() {
        // Force full page reload to the login root, terminating current circuit
        if (window.location.pathname !== '/') {
            window.location.replace('/');
        }
    }

    async function checkCookieAuth() {
        try {
            const response = await fetch('/account/validate', {
                method: 'GET',
                cache: 'no-store',
                credentials: 'same-origin'
            });

            if (!response.ok) {
                handleLogoutEvent();
                return false;
            }

            const data = await response.json();
            if (!data.authenticated) {
                handleLogoutEvent();
                return false;
            }
            return true;
        } catch (e) {
            console.warn('[authSync] Validation request failed:', e);
            return true; // Don't falsely log out on transient network error
        }
    }

    function init() {
        if (isInitialized) return;
        isInitialized = true;

        // 1. Listen for BroadcastChannel events from other tabs
        if (broadcastChannel) {
            broadcastChannel.onmessage = function (event) {
                if (event.data && event.data.type === 'LOGOUT') {
                    handleLogoutEvent();
                }
            };
        }

        // 2. Storage event listener (fallback for multi-tab sync across tabs/windows)
        window.addEventListener('storage', function (e) {
            if (e.key === STORAGE_KEY && e.newValue) {
                try {
                    const payload = JSON.parse(e.newValue);
                    if (payload && payload.type === 'LOGOUT') {
                        handleLogoutEvent();
                    }
                } catch (err) {
                    // Ignore JSON parse errors
                }
            }
        });

        // 3. Tab visibility / focus check (when switching back to an inactive tab)
        document.addEventListener('visibilitychange', function () {
            if (document.visibilityState === 'visible' && window.location.pathname !== '/') {
                checkCookieAuth();
            }
        });

        window.addEventListener('focus', function () {
            if (window.location.pathname !== '/') {
                checkCookieAuth();
            }
        });
    }

    function notifyLogout() {
        try {
            if (broadcastChannel) {
                broadcastChannel.postMessage({ type: 'LOGOUT', timestamp: Date.now() });
            }
            localStorage.setItem(STORAGE_KEY, JSON.stringify({ type: 'LOGOUT', timestamp: Date.now() }));
        } catch (e) {
            console.error('[authSync] Failed to broadcast logout:', e);
        }
    }

    return {
        init: init,
        notifyLogout: notifyLogout,
        validate: checkCookieAuth
    };
})();
