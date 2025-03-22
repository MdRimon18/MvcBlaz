// wwwroot/assets/customjs/spa.js

//async function loadContent(route, params = {}, isPartial = true) {
//    params.isPartial = isPartial;
//    let url = `/${route}`;
//    const query = new URLSearchParams(params).toString();
//    if (query) url += `?${query}`;
//    const mainContainer = document.getElementById("MainContainer");
//    try {
//        const response = await fetch(url, {
//            headers: { "X-Requested-With": "XMLHttpRequest" }
//        });
//        if (response.ok) {
//            const content = await response.text();
            
//            mainContainer.innerHTML = content;
//            bindSpaLinks();
//            // Call route-specific functions
//            initializeRoute(route);
//        } else {
         
//            mainContainer.innerHTML = `<p>Error: Could not load content.</p>`;
//        }
//    } catch (error) {
 
//        mainContainer.innerHTML = `<p>Error: ${error.message}</p>`;
//    }
//}

//function bindSpaLinks() {
//    document.querySelectorAll("a[data-spa]").forEach(link => {
//        link.addEventListener("click", function (e) {
//            e.preventDefault();
//            const route = this.getAttribute("data-spa");
//            const id = this.getAttribute("data-id");
//            const params = id ? { id } : {};
//            loadContent(route, params);
//            history.pushState({ route, params }, "", `/${route}${id ? `?id=${id}` : ""}`);
//        });
//    });
//}

//// Initialize route-specific logic
//function initializeRoute(route) {
//    console.log(route)
//    if (route === "Customer/Index") {
//        window.loadCustomers();
//        window.changePage();
//        window.onRefresh();
//        window.handlePageSizeChanged();
//        window.sortTable();
//        window.bindEvents();
        
//    } else if (route == "Invoice/create") {
//        window.fetchAllProducts();
     
//    }
//    // Add more route-specific initializations as needed
//}

//// Handle page load and reload
//document.addEventListener("DOMContentLoaded", function () {
//    const currentPath = window.location.pathname.slice(1); // e.g., "Invoice/Create"
//    const queryString = window.location.search; // e.g., "?id=123"
//    const params = new URLSearchParams(queryString);
//    const route = currentPath || "Home/Index"; // Default route if none

//    // Load content or initialize based on current route
//    if (document.getElementById("MainContainer")) {
//        loadContent(route, Object.fromEntries(params)); // Load partial content if needed
//    } else {
//        initializeRoute(route); // Just initialize if content is already server-rendered
//    }

//    bindSpaLinks();
//});

//// Handle browser back/forward navigation
//window.onpopstate = function (event) {
//    if (event.state && event.state.route) {
//        loadContent(event.state.route, event.state.params);
//    }
//};

//// Export for global access
//window.loadContent = loadContent;




//function loadPage(url) {
//    $.ajax({
//        url: url,
//        type: 'GET',
//        success: function (data) {
//            console.log(data)
//            $('#MainContainer').html(data); // Update only the content
//            window.history.pushState({}, '', url); // Update URL without reloading

//            if (url == "/Invoice/Create") {
//                window.initializeInvoiceSearch();
//               // window.handleSearch();
//            }
//            else if (url == "/Customer/Index") { 
               
//                    window.loadCustomers();
//                    document.getElementById("checkbox-bulk-customers-select").addEventListener("change", toggleSelectAll);
                 
               
//              //  window.loadCustomers();
//               // window.changePage();
//                //window.onRefresh();
//                //window.handlePageSizeChanged();
//                //window.sortTable();
//               // window.bindEvents();
//            } else {
//                loadPage('/home/index')
//            }
           
//        },
//        error: function () {
//            alert('Error loading page.');
//        }
//    });
//}
 
//window.onpopstate = function () {
//    loadPage(location.pathname);
//};


 
/////
// Mapping object for page-specific initialization logic
const pageInitializers = {
    "/Invoice/Create": () => {
        if (window.initializeInvoiceSearch) window.initializeInvoiceSearch();
    },
    "/Customer/Index": [
        () => { if (window.loadCustomers) window.loadCustomers(); },
        () => { document.getElementById("checkbox-bulk-customers-select").addEventListener("change", toggleSelectAll); }
    ],
    "/InvoicType/index2": (isAjax) => {
        if (isAjax && window.loadTable) window.loadTable();
    }
    // Add more URLs and their initialization functions here as needed
};

// Function to initialize page-specific logic based on URL
function initializePage(url, isAjax = false) {
    const initializers = pageInitializers[url];
    if (initializers) {
        if (Array.isArray(initializers)) {
            // If it's an array, call each function with isAjax
            initializers.forEach(init => init(isAjax));
        } else {
            // If it's a single function, call it with isAjax
            initializers(isAjax);
        }
    } else {
        console.warn(`No initializer found for URL: ${url}`);
    }
}

// Function to load page content via AJAX and update the URL
function loadPage(url) {
    $.ajax({
        url: url,
        type: 'GET',
        success: function (data) {
            $('#MainContainer').html(data); // Update the content container
            window.history.pushState({}, '', url); // Update the browser URL
            initializePage(url, true); // Initialize with isAjax=true
        },
        error: function () {
            alert('Error loading page.');
        }
    });
}

// Handle browser back/forward navigation
window.onpopstate = function () {
    loadPage(location.pathname);
};

// Initialize the page on initial load or full reload
document.addEventListener("DOMContentLoaded", function () {
    initializePage(location.pathname); // Initialize with isAjax=false
});