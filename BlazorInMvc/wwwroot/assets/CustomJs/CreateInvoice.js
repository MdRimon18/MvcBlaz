function InvoiceProductSearch() {
    const searchInput = document.getElementById('chooseProduct');
    const searchDropdown = document.getElementById('searchDropdown');
    console.log(searchInput, searchDropdown);
    searchInput.addEventListener('input', function () {
        if (this.value.length > 0) {
            searchDropdown.style.display = 'block';
            // Add logic here to populate dropdown dynamically based on input
        } else {
            searchDropdown.style.display = 'none';
        }
    });

    document.addEventListener('click', function (e) {
        if (!searchInput.contains(e.target) && !searchDropdown.contains(e.target)) {
            searchDropdown.style.display = 'none';
        }
    });
}

window.InvoiceProductSearch = InvoiceProductSearch;