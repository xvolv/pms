// Network Connectivity & Offline Overlay Monitor with Restored Toast
(function () {
    let overlay = null;
    let toast = null;
    let toastTimer = null;
    let isManuallyDismissed = false;
    let wasOffline = false;

    function getOverlay() {
        if (!overlay) {
            overlay = document.getElementById('network-offline-overlay');
        }
        return overlay;
    }

    function getToast() {
        if (!toast) {
            toast = document.getElementById('network-restored-toast');
        }
        return toast;
    }

    function showOfflineOverlay() {
        wasOffline = true;
        hideToast();
        if (isManuallyDismissed) return;
        const el = getOverlay();
        if (el) {
            el.classList.add('show');
        }
    }

    function hideOfflineOverlay() {
        isManuallyDismissed = false;
        const el = getOverlay();
        if (el) {
            el.classList.remove('show');
        }
        if (wasOffline) {
            wasOffline = false;
            showRestoredToast();
        }
    }

    function showRestoredToast() {
        const t = getToast();
        if (t) {
            t.classList.add('show');
            clearTimeout(toastTimer);
            toastTimer = setTimeout(function () {
                hideToast();
            }, 4000);
        }
    }

    function hideToast() {
        clearTimeout(toastTimer);
        const t = getToast();
        if (t) {
            t.classList.remove('show');
        }
    }

    async function checkServerConnection() {
        try {
            const controller = new AbortController();
            const timeoutId = setTimeout(() => controller.abort(), 3000);

            const response = await fetch('/account/validate', {
                method: 'GET',
                cache: 'no-store',
                signal: controller.signal
            });
            clearTimeout(timeoutId);

            if (response.ok || response.status === 401) {
                hideOfflineOverlay();
                return true;
            } else {
                showOfflineOverlay();
                return false;
            }
        } catch (err) {
            showOfflineOverlay();
            return false;
        }
    }

    function initNetworkMonitor() {
        // Initial state
        if (!navigator.onLine) {
            showOfflineOverlay();
        }

        // Browser online/offline event listeners
        window.addEventListener('offline', function () {
            isManuallyDismissed = false;
            showOfflineOverlay();
        });

        window.addEventListener('online', function () {
            checkServerConnection();
        });

        // Periodic connectivity check if offline
        setInterval(function () {
            if (!navigator.onLine) {
                showOfflineOverlay();
            }
        }, 4000);
    }

    // Initialize when DOM is ready
    if (document.readyState === 'loading') {
        document.addEventListener('DOMContentLoaded', initNetworkMonitor);
    } else {
        initNetworkMonitor();
    }

    window.dismissOfflineOverlay = function () {
        isManuallyDismissed = true;
        const el = getOverlay();
        if (el) {
            el.classList.remove('show');
        }
    };

    window.dismissReconnectModal = function () {
        const reconnectModal = document.getElementById('components-reconnect-modal');
        if (reconnectModal) {
            reconnectModal.classList.remove('components-reconnect-show', 'components-reconnect-failed', 'components-reconnect-rejected');
            reconnectModal.style.display = 'none';
        }
    };

    window.hideRestoredToast = hideToast;
})();
