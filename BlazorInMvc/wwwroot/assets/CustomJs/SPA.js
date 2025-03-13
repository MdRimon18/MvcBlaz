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


