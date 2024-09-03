const interSectionObserverOptions = {
    root: null,
    rootMargin: "0px",
    threshold: 0.2
}

function handleIntersect(entries, observer) {
    entries.forEach(entry => {
        if (entry.isIntersecting){
            entry.target.classList.add("show")
            observer.unobserve(entry.target)
        }
    });
}

const observer = new IntersectionObserver(handleIntersect, interSectionObserverOptions)

Array.from(document.getElementsByClassName("observe")).forEach(target => {
    observer.observe(target);
});

var coll = Array.from(document.getElementsByClassName("faq"));
coll.forEach(i => {
    i.addEventListener("click",function(){
        this.classList.toggle("active")
    });
})

const checkboxes = document.querySelectorAll('.filters-container input[type="checkbox"]');

checkboxes.forEach(checkbox => {
    checkbox.addEventListener("change", () => {
        const url = new URL(window.location);
        let types = url.searchParams.get('types') ? url.searchParams.get('types').split(',') : [];

        if (checkbox.checked) {
            types.push(checkbox.name);
        } else {
            types = types.filter(type => type !== checkbox.name);
        }

        if (types.length > 0) {
            url.searchParams.set('types', types.join(','));
        } else {
            url.searchParams.delete('types');
        }

        window.history.pushState({}, '', url);

        window.location.reload();
    })
})

function updateSortQueryParam() {
    var selectElement = document.getElementById('sort');
    var selectedValue = selectElement.value;
    
    var url = new URL(window.location.href);
    url.searchParams.set('sortBy', selectedValue);
    
    window.history.pushState({}, '', url);

    window.location.reload();
}


function incrementAmount(){
    const url = new URL(window.location);
    let amount = parseInt(url.searchParams.get('amount') ?? 1);

    url.searchParams.set("amount", amount + 1);

    document.getElementById("amount").innerHTML = amount + 1;
    document.getElementById("amount-input").value = amount + 1;

    window.history.pushState({}, '', url);
}

function decrementAmount(){
    const url = new URL(window.location);
    let amount = parseInt(url.searchParams.get('amount') ?? 1);

    if (amount > 1){
        url.searchParams.set("amount", amount - 1);

        document.getElementById("amount").innerHTML = amount - 1;
        document.getElementById("amount-input").value = amount - 1;
    
        window.history.pushState({}, '', url);
    }
}