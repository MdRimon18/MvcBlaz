let pagination = {
    currentPage: 1,
    pageSize: 10,
    sortOrder: 'asc',
    sortField: 'customerName',
    totalPages: 0,
    totalRecords: 0
};

 
           // Define variables as a global object for easier management
 
        // Load customers when the page is ready (uncomment if needed)
        // document.addEventListener("DOMContentLoaded", function () {
        //     loadCustomers();
        // });

        // Fetch and load customer data
        async function loadCustomers() {
            try {
                const url = `/Customer/Index?isPartial=true&page=${pagination.currentPage}&pageSize=${pagination.pageSize}&sortField=${pagination.sortField}&sortOrder=${pagination.sortOrder}`;
                const response = await fetch(url);
                if (!response.ok) throw new Error(`HTTP error! Status: ${response.status}`);
                const content = await response.text();
                document.getElementById("MainContainer").innerHTML = content; // Match ID with your partial view
                updatePaginationFromHiddenFields();
                bindEvents(); // Rebind events after DOM update
                updatePaginationInfo(); // Update UI with latest pagination info
            } catch (error) {
                console.error('Error fetching customers:', error);
            }
        }
            // Update pagination object from hidden fields
        function updatePaginationFromHiddenFields() {
        pagination.currentPage = parseInt(document.getElementById('hiddenCurrentPage')?.value, 10) || 1;
    pagination.pageSize = parseInt(document.getElementById('hiddenPageSize')?.value, 10) || 10;
    pagination.sortOrder = document.getElementById('hiddenSortOrder')?.value || 'asc';
    pagination.sortField = document.getElementById('hiddenSortField')?.value || 'customerName';
    pagination.totalPages = parseInt(document.getElementById('hiddenTotalPages')?.value, 10) || 0;
    pagination.totalRecords = parseInt(document.getElementById('hiddenTotalRecords')?.value, 10) || 0;
        }
    // Change page and reload data
    function changePage(page) {

        updatePaginationFromHiddenFields();
    if (page < 1 || page > pagination.totalPages) return;
    pagination.currentPage = page;
    loadCustomers();
        }

    // Handle page size change and reload data
    function handlePageSizeChanged(newSize) {
        pagination.pageSize = parseInt(newSize, 10);
    pagination.currentPage = 1; // Reset to first page
    loadCustomers();
        }

    // Refresh the customer list
    function onRefresh() {
        loadCustomers();
        }

    // Sort table and reload data
    function sortTable(field) {
            if (pagination.sortField === field) {
        pagination.sortOrder = pagination.sortOrder === 'asc' ? 'desc' : 'asc';
            } else {
        pagination.sortField = field;
    pagination.sortOrder = 'asc';
            }
    loadCustomers();
        }
    // Update pagination info in the UI
    function updatePaginationInfo() {
            const infoElement = document.getElementById('pagination-info');
    if (infoElement) {
        infoElement.textContent = `Page ${pagination.currentPage} of ${pagination.totalPages}, Total Records: ${pagination.totalRecords}`;
            }

    // Update pagination buttons state
    const prevButton = document.querySelector('button[title="Previous"]');
    const nextButton = document.querySelector('button[title="Next"]');
    if (prevButton) prevButton.disabled = pagination.currentPage === 1;
    if (nextButton) nextButton.disabled = pagination.currentPage === pagination.totalPages;
        }

    // Bind events to dynamically loaded elements (if needed)
    function bindEvents() {
        // Example: Rebind click events for sortable headers or pagination links if needed
        document.querySelectorAll('.sortable-header').forEach(header => {
            header.onclick = () => sortTable(header.dataset.sort);
        });
    document.getElementById("checkbox-bulk-customers-select").addEventListener("change", toggleSelectAll);
             document.querySelectorAll("#table-customers-body .form-check-input").forEach(checkbox => {
        checkbox.addEventListener("change", toggleBulkActions);
             });
            // Add more event bindings as required (e.g., for checkboxes, dropdowns)
        }
        // function updatePaginationInfo() {
        //     const paginationInfo = document.getElementById("pagination-info");
        //     paginationInfo.innerText = `Page ${currentPage} of ${totalPages}, Total Records: ${totalRecords}`;
        // }

        // function bindEvents() {
        //     document.getElementById("checkbox-bulk-customers-select").addEventListener("change", toggleSelectAll);
        //     document.querySelectorAll("#table-customers-body .form-check-input").forEach(checkbox => {
        //         checkbox.addEventListener("change", toggleBulkActions);
        //     });
        // }

        function toggleSelectAll() {
            const selectAllCheckbox = document.getElementById("checkbox-bulk-customers-select");
            const checkboxes = document.querySelectorAll("#table-customers-body .form-check-input");
            checkboxes.forEach(checkbox => {
                checkbox.checked = selectAllCheckbox.checked;
            });
            toggleBulkActions();
        }

        function toggleBulkActions() {
            const checkboxes = document.querySelectorAll("#table-customers-body .form-check-input");
            const anyChecked = Array.from(checkboxes).some(checkbox => checkbox.checked);
    const actionsElement = document.getElementById("table-customers-actions");
    const replaceElement = document.getElementById("table-customers-replace-element");
    if (anyChecked) {
        actionsElement.classList.remove("d-none");
    replaceElement.classList.add("d-none");
            } else {
        actionsElement.classList.add("d-none");
    replaceElement.classList.remove("d-none");
            }
        }

    async function applyBulkAction() {
            const selectedAction = document.getElementById("bulk-action-select").value;
    const selectedCustomers = Array.from(document.querySelectorAll("#table-customers-body .form-check-input:checked"))
                .map(checkbox => checkbox.id.replace("customer-", ""));

    if (selectedCustomers.length === 0) {
        alert("No customers selected.");
    return;
            }
    console.log(selectedAction, selectedCustomers);
    try {
                const response = await fetch(`/api/Customer/BulkAction`, {
        method: "POST",
    headers: {
        "Content-Type": "application/json"
                    },
    body: JSON.stringify({
        action: selectedAction,
    customerIds: selectedCustomers
                    })
                });

    if (response.ok) {
        alert("Bulk action applied successfully.");
    loadCustomers();
                } else {
        alert("Failed to apply bulk action.");
                }
            } catch (error) {
        console.error("Error applying bulk action:", error);
            }
}


window.loadCustomers = loadCustomers; // Make it globally accessible
window.changePage = changePage;
window.sortTable = sortTable;
window.handlePageSizeChanged = handlePageSizeChanged;
window.onRefresh = onRefresh;
window.applyBulkAction = applyBulkAction;