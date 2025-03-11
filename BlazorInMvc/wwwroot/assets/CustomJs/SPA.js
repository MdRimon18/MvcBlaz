// wwwroot/assets/customjs/spa.js

async function loadContent(route, params = {}, isPartial = true) {
    params.isPartial = isPartial;
    let url = `/${route}`;
    const query = new URLSearchParams(params).toString();
    if (query) url += `?${query}`;
    const mainContainer = document.getElementById("MainContainer");
    try {
        const response = await fetch(url, {
            headers: { "X-Requested-With": "XMLHttpRequest" }
        });
        if (response.ok) {
            const content = await response.text();
            
            mainContainer.innerHTML = content;
            bindSpaLinks();
            // Call route-specific functions
            initializeRoute(route);
        } else {
         
            mainContainer.innerHTML = `<p>Error: Could not load content.</p>`;
        }
    } catch (error) {
 
        mainContainer.innerHTML = `<p>Error: ${error.message}</p>`;
    }
}

function bindSpaLinks() {
    document.querySelectorAll("a[data-spa]").forEach(link => {
        link.addEventListener("click", function (e) {
            e.preventDefault();
            const route = this.getAttribute("data-spa");
            const id = this.getAttribute("data-id");
            const params = id ? { id } : {};
            loadContent(route, params);
            history.pushState({ route, params }, "", `/${route}${id ? `?id=${id}` : ""}`);
        });
    });
}

// Initialize route-specific logic
function initializeRoute(route) {
    console.log(route)
    if (route === "Customer/Index") {
        window.loadCustomers();
        window.changePage();
        window.onRefresh();
        window.handlePageSizeChanged();
        window.sortTable();
        window.bindEvents();
        
    } else if (route == "Invoice/create") {
        window.fetchAllProducts();
     
    }
    // Add more route-specific initializations as needed
}

// Handle page load and reload
document.addEventListener("DOMContentLoaded", function () {
    const currentPath = window.location.pathname.slice(1); // e.g., "Invoice/Create"
    const queryString = window.location.search; // e.g., "?id=123"
    const params = new URLSearchParams(queryString);
    const route = currentPath || "Home/Index"; // Default route if none

    // Load content or initialize based on current route
    if (document.getElementById("MainContainer")) {
        loadContent(route, Object.fromEntries(params)); // Load partial content if needed
    } else {
        initializeRoute(route); // Just initialize if content is already server-rendered
    }

    bindSpaLinks();
});

// Handle browser back/forward navigation
window.onpopstate = function (event) {
    if (event.state && event.state.route) {
        loadContent(event.state.route, event.state.params);
    }
};

// Export for global access
window.loadContent = loadContent;


// Invoice Search Functionality
(function () {
    let allProducts = [];
    let isInitialized = false;

    // Fetch products
    async function fetchAllProducts() {
        try {
            const response = await fetch('/api/GetProducts');
            const data = await response.json();
            allProducts = data.isSuccess ? data.product_list : [];
            console.log('[DEBUG] All products fetched:', allProducts);
            isInitialized = true;
        } catch (error) {
            console.error('Error fetching products:', error);
            allProducts = [];
            isInitialized = true;
        }
    }

    // Get DOM elements dynamically
    function getElements() {
        return {
            searchInput: document.getElementById('chooseProduct'),
            searchDropdown: document.getElementById('searchDropdown'),
            dropdownList: document.querySelector('#searchDropdown .list'),
            noResultsMessage: document.querySelector('#searchDropdown .text-center p')
        };
    }

    // Filter products
    function filterProducts(query) {
        
        if (!query) return [];
        query = query.toLowerCase().trim();
        console.log('[DEBUG] Filtering with query:', query);
        return allProducts.filter(product =>
            product.prodName?.toLowerCase().includes(query) ||
            product.sku?.toLowerCase().includes(query) ||
            product.productCode?.toLowerCase().includes(query)
        );
    }

    // Populate dropdown
    function populateDropdown(products, elements) {
        elements.dropdownList.innerHTML = '';
        console.log('[DEBUG] Populating dropdown with:', products);
        if (products.length > 0) {
            elements.noResultsMessage.classList.add('d-none');
            products.forEach(product => {
                const item = document.createElement('a');
                item.className = 'dropdown-item px-x1 py-2';
                item.href = '#';
                item.innerHTML = `
                    <div class="d-flex align-items-center">
                        <div class="avatar avatar-l me-2">
                            <img class="rounded-circle" src="${product.imageUrl || '../../assets/img/default-product.jpg'}" alt="${product.prodName}" />
                        </div>
                        <div class="flex-1">
                            <h6 class="mb-0 title">${product.prodName}</h6>
                            <p class="fs-11 mb-0 d-flex">${product.sku || product.productCode || 'N/A'}</p>
                        </div>
                    </div>
                `;
                item.addEventListener('click', () => {
                    elements.searchInput.value = product.prodName;
                    elements.searchDropdown.style.display = 'none';
                });
                elements.dropdownList.appendChild(item);
            });
        } else {
            elements.noResultsMessage.classList.remove('d-none');
        }
    }

    // Global handleSearch for oninput
    window.handleSearch = function (query) {
        console.log('[DEBUG] handleSearch called via oninput with query:', query);
        if (!isInitialized) {
            console.log('[DEBUG] Products not yet loaded, waiting...');
            return;
        }
        const elements = getElements();
        if (!elements.searchInput || !elements.searchDropdown || !elements.dropdownList || !elements.noResultsMessage) {
            console.error('[DEBUG] Elements not found in handleSearch:', elements);
            return;
        }
        console.log('[DEBUG] searchInput value from DOM:', elements.searchInput.value); // Cross-check
        if (query.length > 0) {
            elements.searchDropdown.style.display = 'block';
            const filteredProducts = filterProducts(query);
            populateDropdown(filteredProducts, elements);
        } else {
            elements.searchDropdown.style.display = 'none';
            elements.dropdownList.innerHTML = '';
            elements.noResultsMessage.classList.add('d-none');
        }
    };

    // Initialize search functionality
    window.initializeInvoiceSearch = async function () {
        console.log('[DEBUG] Initializing Invoice search');
        const elements = getElements();
        if (!elements.searchInput || !elements.searchDropdown) {
            console.error('[DEBUG] Required elements not found after render:', elements);
            return;
        }
        await fetchAllProducts(); // Fetch products and set isInitialized

        // Attach click-outside listener (no input listener needed due to oninput)
        document.addEventListener('click', (e) => {
            if (!elements.searchInput.contains(e.target) && !elements.searchDropdown.contains(e.target)) {
                elements.searchDropdown.style.display = 'none';
            }
        });
    };

    // Expose fetchAllProducts for debugging (optional)
    window.fetchAllProducts = fetchAllProducts;
})();