
window.DxDocViewer = {

    /**
     * Finds the printable document element by ID or falls back to any sheet container
     */
    getElement: function (elementId) {
        var el = document.getElementById(elementId);
        if (!el) {
            el = document.querySelector('.dx-doc-page-sheet');
        }
        return el;
    },

    /**
     * Isolated High-Fidelity Printing via Hidden IFrame
     * Ensures ONLY the document sheet prints - NO search bar, NO toolbar, NO window chrome!
     */
    print: function (elementId) {
        var el = this.getElement(elementId);
        if (!el) {
            window.print();
            return;
        }

        var iframe = document.getElementById('dx-isolated-print-iframe');
        if (!iframe) {
            iframe = document.createElement('iframe');
            iframe.id = 'dx-isolated-print-iframe';
            iframe.style.position = 'fixed';
            iframe.style.right = '0';
            iframe.style.bottom = '0';
            iframe.style.width = '0';
            iframe.style.height = '0';
            iframe.style.border = '0';
            iframe.style.opacity = '0';
            iframe.style.pointerEvents = 'none';
            document.body.appendChild(iframe);
        }

        var doc = iframe.contentWindow.document;
        doc.open();

        // Clone document content and clean UI-only elements
        var clone = el.cloneNode(true);
        clone.querySelectorAll('.dx-doc-margin-guides, mark.dx-search-hit, .no-print, button').forEach(function (n) {
            if (n.classList.contains('dx-search-hit')) {
                var parent = n.parentNode;
                parent.replaceChild(document.createTextNode(n.innerText), n);
            } else {
                n.remove();
            }
        });

        // Collect all stylesheets from main document
        var styles = '';
        document.querySelectorAll('link[rel="stylesheet"]').forEach(function (link) {
            styles += '<link rel="stylesheet" href="' + link.href + '">';
        });
        document.querySelectorAll('style').forEach(function (s) {
            styles += s.outerHTML;
        });

        var printStyles = '<style>' +
            // The copied stylesheets include devexpress-print-preview.css, whose
            // own @media print rules hide the whole page except
            // .dx-doc-viewer-backdrop (the fallback path for a plain
            // window.print()). This iframe's body IS already just the isolated
            // print content - it never has that backdrop wrapper - so that
            // inherited rule would hide everything with nothing left to
            // restore, printing a blank page. Force it back to visible here,
            // after the copied sheets so this wins the cascade.
            '@media print { body, body * { visibility: visible !important; } } ' +
            '@page { size: auto; margin: 8mm 10mm; } ' +
            'html, body { background: #fff !important; margin: 0 !important; padding: 0 !important; width: 100% !important; height: auto !important; } ' +
            '.dx-doc-page-sheet { box-shadow: none !important; width: 100% !important; min-height: auto !important; padding: 0 !important; margin: 0 !important; } ' +
            'table { width: 100% !important; border-collapse: collapse !important; } ' +
            'th, td { border: 1px solid #777 !important; } ' +
            'th { background: #eee !important; -webkit-print-color-adjust: exact; print-color-adjust: exact; } ' +
            '</style>';

        doc.write('<!DOCTYPE html><html><head><meta charset="utf-8"/><title>Document</title>' + styles + printStyles + '</head><body>' + clone.outerHTML + '</body></html>');
        doc.close();

        
        var linkEls = Array.prototype.slice.call(doc.querySelectorAll('link[rel="stylesheet"]'));
        var pending = linkEls.length;
        var printed = false;
        function triggerPrint() {
            if (printed) return;
            printed = true;
            iframe.contentWindow.focus();
            iframe.contentWindow.print();
        }
        function onOneSettled() {
            pending--;
            if (pending <= 0) {
                setTimeout(triggerPrint, 50);
            }
        }
        if (pending === 0) {
            setTimeout(triggerPrint, 50);
        } else {
            linkEls.forEach(function (link) {
                link.addEventListener('load', onOneSettled);
                link.addEventListener('error', onOneSettled);
            });
        }
        // Safety net in case a stylesheet never fires load/error.
        setTimeout(triggerPrint, 2000);
    },

    /**
     * Trigger Open File Dialog from Folder Icon
     */
    openFileDialog: function (inputId) {
        var input = document.getElementById(inputId || 'dx-doc-file-uploader');
        if (input) {
            input.click();
        }
    },

    /**
     * Export Document to Excel (.xlsx / .xls compatible XML)
     */
    exportToExcel: function (elementId, title) {
        var el = this.getElement(elementId);
        if (!el) {
            console.error("Print element not found: " + elementId);
            return;
        }

        var fileName = (title || "Document").replace(/[/\\?%*:|"<>]/g, '_') + '.xls';

        var tables = el.querySelectorAll('table');
        var htmlContent = '';

        // Capture headers and metadata
        var headers = el.querySelectorAll('.dx-report-header, .ledger-header, .rc-title-bar, .print-header-block, .dx-report-meta-row, .ledger-title-strip, .cust-info-table, .conf-top-header, .conf-main-title, .pf-header-grid');
        if (headers.length > 0) {
            headers.forEach(function (h) {
                htmlContent += h.outerHTML;
            });
        }

        if (tables.length > 0) {
            tables.forEach(function (t) {
                htmlContent += t.outerHTML;
            });
        } else {
            htmlContent += el.innerHTML;
        }

        // Clean out action buttons/guides from export HTML
        var tempDiv = document.createElement('div');
        tempDiv.innerHTML = htmlContent;
        tempDiv.querySelectorAll('.dx-doc-margin-guides, .dx-doc-watermark, .no-print, button').forEach(function (n) {
            n.remove();
        });

        var excelTemplate = '<html xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/TR/REC-html40">' +
            '<head><meta charset="utf-8"/><style>' +
            'body { font-family: Segoe UI, Arial, sans-serif; font-size: 11pt; } ' +
            'table { border-collapse: collapse; width: 100%; margin-bottom: 20px; } ' +
            'th { background-color: #D9D9D9; color: #000000; font-weight: bold; border: 1px solid #7F7F7F; padding: 6px 10px; text-align: left; } ' +
            'td { border: 1px solid #BFBFBF; padding: 5px 8px; vertical-align: middle; } ' +
            '.dx-report-hotel-title, .print-hotel-name { font-size: 16pt; font-weight: bold; text-align: center; } ' +
            '.dx-report-doc-title, .print-doc-title { font-size: 14pt; font-weight: bold; text-align: center; margin-bottom: 10px; } ' +
            '</style><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>' +
            (title ? title.substring(0, 30) : 'Report') +
            '</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head>' +
            '<body>' + tempDiv.innerHTML + '</body></html>';

        var blob = new Blob([excelTemplate], { type: 'application/vnd.ms-excel;charset=utf-8;' });
        this.downloadBlob(blob, fileName);
    },

    /**
     * Export Document to standard CSV
     */
    exportToCsv: function (elementId, title) {
        var el = this.getElement(elementId);
        if (!el) return;

        var fileName = (title || "Document").replace(/[/\\?%*:|"<>]/g, '_') + '.csv';
        var csv = '';

        var titleNode = el.querySelector('.dx-report-doc-title, .print-doc-title, .rc-title-bar, .ledger-title-box, .conf-main-title');
        if (titleNode) {
            csv += '"' + titleNode.innerText.replace(/"/g, '""').trim() + '"\r\n\r\n';
        }

        var tables = el.querySelectorAll('table');
        if (tables.length > 0) {
            tables.forEach(function (table, tIndex) {
                if (tIndex > 0) csv += '\r\n';
                var rows = table.querySelectorAll('tr');
                rows.forEach(function (row) {
                    var cols = row.querySelectorAll('th, td');
                    var rowData = [];
                    cols.forEach(function (col) {
                        var text = col.innerText.replace(/\r?\n|\r/g, ' ').replace(/"/g, '""').trim();
                        rowData.push('"' + text + '"');
                    });
                    if (rowData.length > 0) {
                        csv += rowData.join(',') + '\r\n';
                    }
                });
            });
        } else {
            var lines = el.innerText.split(/\r?\n/);
            lines.forEach(function (line) {
                var trimmed = line.trim();
                if (trimmed) {
                    csv += '"' + trimmed.replace(/"/g, '""') + '"\r\n';
                }
            });
        }

        var blob = new Blob(["\uFEFF" + csv], { type: 'text/csv;charset=utf-8;' });
        this.downloadBlob(blob, fileName);
    },

    /**
     * Export Document to Word Document (.doc / XML)
     */
    exportToWord: function (elementId, title) {
        var el = this.getElement(elementId);
        if (!el) return;

        var fileName = (title || "Document").replace(/[/\\?%*:|"<>]/g, '_') + '.doc';

        var tempDiv = document.createElement('div');
        tempDiv.innerHTML = el.innerHTML;
        tempDiv.querySelectorAll('.dx-doc-margin-guides, .dx-doc-watermark, .no-print, button').forEach(function (n) {
            n.remove();
        });

        var wordTemplate = '<html xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:w="urn:schemas-microsoft-com:office:word" xmlns="http://www.w3.org/TR/REC-html40">' +
            '<head><meta charset="utf-8"/><title>' + (title || 'Document') + '</title>' +
            '<style>' +
            '@page WordSection1 { size: 595.3pt 841.9pt; margin: 36.0pt 36.0pt 36.0pt 36.0pt; } ' +
            'div.WordSection1 { page: WordSection1; } ' +
            'body { font-family: "Segoe UI", Arial, sans-serif; font-size: 10.5pt; color: #000; } ' +
            'table { border-collapse: collapse; width: 100%; margin: 12pt 0; } ' +
            'th { background-color: #ECECEC; font-weight: bold; border: 1pt solid #777; padding: 5pt; text-align: left; } ' +
            'td { border: 1pt solid #AAA; padding: 4pt 6pt; } ' +
            '.dx-report-hotel-title, .print-hotel-name { font-size: 16pt; font-weight: bold; text-align: center; } ' +
            '.dx-report-doc-title, .print-doc-title { font-size: 14pt; font-weight: bold; text-align: center; margin-bottom: 12pt; } ' +
            '</style></head>' +
            '<body><div class="WordSection1">' + tempDiv.innerHTML + '</div></body></html>';

        var blob = new Blob([wordTemplate], { type: 'application/msword;charset=utf-8;' });
        this.downloadBlob(blob, fileName);
    },

    /**
     * Export Document to Standalone HTML Page
     */
    exportToHtml: function (elementId, title) {
        var el = this.getElement(elementId);
        if (!el) return;

        var fileName = (title || "Document").replace(/[/\\?%*:|"<>]/g, '_') + '.html';

        var tempDiv = document.createElement('div');
        tempDiv.innerHTML = el.innerHTML;
        tempDiv.querySelectorAll('.dx-doc-margin-guides, .dx-doc-watermark, .no-print, button').forEach(function (n) {
            n.remove();
        });

        var htmlDoc = '<!DOCTYPE html><html><head><meta charset="utf-8"/><title>' + (title || 'Document') + '</title>' +
            '<style>' +
            'body { font-family: "Segoe UI", Arial, sans-serif; font-size: 12px; color: #111; padding: 30px; max-width: 900px; margin: 0 auto; } ' +
            'table { width: 100%; border-collapse: collapse; margin: 15px 0 25px; } ' +
            'th { background: #E4E4E4; font-weight: 700; border: 1px solid #888; padding: 6px 8px; text-align: left; } ' +
            'td { border: 1px solid #AAA; padding: 5px 8px; } ' +
            'tbody tr:nth-child(even) { background: #FAFAFA; } ' +
            '.dx-report-hotel-title, .print-hotel-name { font-size: 18px; font-weight: 800; text-align: center; } ' +
            '.dx-report-doc-title, .print-doc-title { font-size: 15px; font-weight: 700; text-align: center; margin-bottom: 15px; } ' +
            '.dx-report-signatures, .print-signatures-container, .reg-print-signatures { display: flex; justify-content: space-between; margin-top: 40px; } ' +
            '.dx-report-sig-col, .print-sig-col, .reg-sig-col { width: 22%; text-align: center; } ' +
            '.dx-report-sig-line, .print-sig-line, .reg-sig-line { border-top: 1.5px solid #000; margin-bottom: 4px; } ' +
            '</style></head>' +
            '<body>' + tempDiv.innerHTML + '</body></html>';

        var blob = new Blob([htmlDoc], { type: 'text/html;charset=utf-8;' });
        this.downloadBlob(blob, fileName);
    },

    /**
     * Export Document to Clean Formatted Plain Text (*.txt)
     */
    exportToTxt: function (elementId, title) {
        var el = this.getElement(elementId);
        if (!el) return;

        var fileName = (title || "Document").replace(/[/\\?%*:|"<>]/g, '_') + '.txt';
        var textContent = '';

        textContent += '================================================================================\r\n';
        textContent += (title || 'DOCUMENT').toUpperCase() + '\r\n';
        textContent += 'Date: ' + new Date().toLocaleDateString() + '\r\n';
        textContent += '================================================================================\r\n\r\n';

        var tables = el.querySelectorAll('table');
        if (tables.length > 0) {
            tables.forEach(function (table) {
                var rows = table.querySelectorAll('tr');
                rows.forEach(function (row) {
                    var cols = row.querySelectorAll('th, td');
                    var line = [];
                    cols.forEach(function (c) {
                        line.push(c.innerText.replace(/\r?\n|\r/g, ' ').trim());
                    });
                    textContent += line.join('\t | \t') + '\r\n';
                });
                textContent += '\r\n';
            });
        } else {
            textContent += el.innerText;
        }

        var blob = new Blob([textContent], { type: 'text/plain;charset=utf-8;' });
        this.downloadBlob(blob, fileName);
    },

    /**
     * Helper to download any created Blob
     */
    downloadBlob: async function (blob, fileName) {
        if (window.showSaveFilePicker) {
            var ext = (fileName.split('.').pop() || '').toLowerCase();
            try {
                // showSaveFilePicker's accept option requires a bare "type/subtype"
                // MIME string - no ";charset=..." parameters - or it throws a TypeError.
                var mime = (blob.type || 'application/octet-stream').split(';')[0].trim();
                var accept = {};
                accept[mime] = ['.' + ext];
                var handle = await window.showSaveFilePicker({
                    suggestedName: fileName,
                    types: [{ description: ext.toUpperCase() + ' File', accept: accept }]
                });
                var writable = await handle.createWritable();
                await writable.write(blob);
                await writable.close();
                return;
            } catch (err) {
                if (err && err.name === 'AbortError') {
                    // User cancelled the save dialog - do not fall back to a silent download.
                    return;
                }
                console.warn('showSaveFilePicker failed, falling back to direct download:', err);
            }
        }

        var link = document.createElement('a');
        link.href = URL.createObjectURL(blob);
        link.download = fileName;
        document.body.appendChild(link);
        link.click();
        setTimeout(function () {
            document.body.removeChild(link);
            URL.revokeObjectURL(link.href);
        }, 100);
    },

    /**
     * Interactive Search / Find inside Preview Document
     */
    searchState: {
        matches: [],
        currentIndex: -1
    },

    findInDocument: function (elementId, query) {
        var el = this.getElement(elementId);
        if (!el) return { count: 0, current: 0 };

        // Clear previous highlights
        var previousHighlights = el.querySelectorAll('mark.dx-search-hit');
        previousHighlights.forEach(function (mark) {
            var parent = mark.parentNode;
            parent.replaceChild(document.createTextNode(mark.innerText), mark);
            parent.normalize();
        });

        this.searchState.matches = [];
        this.searchState.currentIndex = -1;

        if (!query || query.trim() === '') {
            return { count: 0, current: 0 };
        }

        var searchTerm = query.toLowerCase();
        var walker = document.createTreeWalker(el, NodeFilter.SHOW_TEXT, null, false);
        var nodesToReplace = [];

        while (walker.nextNode()) {
            var node = walker.currentNode;
            if (node.parentNode && node.parentNode.classList &&
                (node.parentNode.classList.contains('dx-doc-margin-guides') ||
                 node.parentNode.classList.contains('dx-doc-watermark'))) {
                continue;
            }
            if (node.nodeValue.toLowerCase().indexOf(searchTerm) !== -1) {
                nodesToReplace.push(node);
            }
        }

        var self = this;
        nodesToReplace.forEach(function (textNode) {
            var val = textNode.nodeValue;
            var lowerVal = val.toLowerCase();
            var frag = document.createDocumentFragment();
            var lastIdx = 0;
            var idx = lowerVal.indexOf(searchTerm, lastIdx);

            while (idx !== -1) {
                if (idx > lastIdx) {
                    frag.appendChild(document.createTextNode(val.substring(lastIdx, idx)));
                }
                var mark = document.createElement('mark');
                mark.className = 'dx-search-hit';
                mark.style.backgroundColor = '#fff176';
                mark.style.color = '#000';
                mark.style.padding = '1px 2px';
                mark.style.borderRadius = '2px';
                mark.style.boxShadow = '0 0 2px rgba(0,0,0,0.4)';
                mark.innerText = val.substring(idx, idx + searchTerm.length);

                frag.appendChild(mark);
                self.searchState.matches.push(mark);

                lastIdx = idx + searchTerm.length;
                idx = lowerVal.indexOf(searchTerm, lastIdx);
            }

            if (lastIdx < val.length) {
                frag.appendChild(document.createTextNode(val.substring(lastIdx)));
            }

            if (textNode.parentNode) {
                textNode.parentNode.replaceChild(frag, textNode);
            }
        });

        if (this.searchState.matches.length > 0) {
            this.searchState.currentIndex = 0;
            this.highlightActiveMatch();
        }

        return {
            count: this.searchState.matches.length,
            current: this.searchState.matches.length > 0 ? 1 : 0
        };
    },

    findNext: function () {
        if (this.searchState.matches.length === 0) return { count: 0, current: 0 };
        this.searchState.currentIndex = (this.searchState.currentIndex + 1) % this.searchState.matches.length;
        this.highlightActiveMatch();
        return {
            count: this.searchState.matches.length,
            current: this.searchState.currentIndex + 1
        };
    },

    findPrev: function () {
        if (this.searchState.matches.length === 0) return { count: 0, current: 0 };
        this.searchState.currentIndex = (this.searchState.currentIndex - 1 + this.searchState.matches.length) % this.searchState.matches.length;
        this.highlightActiveMatch();
        return {
            count: this.searchState.matches.length,
            current: this.searchState.currentIndex + 1
        };
    },

    highlightActiveMatch: function () {
        this.searchState.matches.forEach(function (m, idx) {
            m.style.backgroundColor = '#fff176';
            m.style.outline = 'none';
        });

        var active = this.searchState.matches[this.searchState.currentIndex];
        if (active) {
            active.style.backgroundColor = '#ff9800';
            active.style.outline = '2px solid #e65100';
            active.scrollIntoView({ behavior: 'smooth', block: 'center' });
        }
    },

    /**
     * Initializes Canvas Pan (Hand Tool)
     */
    initPanTool: function (workspaceSelector, isEnabled) {
        var workspace = document.querySelector(workspaceSelector || '.dx-doc-workspace');
        if (!workspace) return;

        if (!workspace._panHandlersAttached) {
            var isDown = false;
            var startX, startY, scrollLeft, scrollTop;

            workspace.addEventListener('mousedown', function (e) {
                if (!workspace.classList.contains('is-hand-tool')) return;
                isDown = true;
                workspace.style.cursor = 'grabbing';
                startX = e.pageX - workspace.offsetLeft;
                startY = e.pageY - workspace.offsetTop;
                scrollLeft = workspace.scrollLeft;
                scrollTop = workspace.scrollTop;
            });

            workspace.addEventListener('mouseleave', function () {
                isDown = false;
                if (workspace.classList.contains('is-hand-tool')) {
                    workspace.style.cursor = 'grab';
                }
            });

            workspace.addEventListener('mouseup', function () {
                isDown = false;
                if (workspace.classList.contains('is-hand-tool')) {
                    workspace.style.cursor = 'grab';
                }
            });

            workspace.addEventListener('mousemove', function (e) {
                if (!isDown) return;
                e.preventDefault();
                var x = e.pageX - workspace.offsetLeft;
                var y = e.pageY - workspace.offsetTop;
                var walkX = (x - startX) * 1.5;
                var walkY = (y - startY) * 1.5;
                workspace.scrollLeft = scrollLeft - walkX;
                workspace.scrollTop = scrollTop - walkY;
            });

            workspace._panHandlersAttached = true;
        }

        if (isEnabled) {
            workspace.classList.add('is-hand-tool');
            workspace.style.cursor = 'grab';
        } else {
            workspace.classList.remove('is-hand-tool');
            workspace.style.cursor = 'default';
        }
    }
};
