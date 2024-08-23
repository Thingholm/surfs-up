loadHeader();

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

function loadHeader() {
    fetch('components/header.html')
    .then(response => response.text())
    .then(data => {
        document.getElementById('header').innerHTML = data;
        findCurrentUrl();
    })
    .catch(error => console.error('Error loading header:', error));
}

Array.from(document.getElementsByClassName("observe")).forEach(target => {
    observer.observe(target);
});

function findCurrentUrl(){
    const pathname = window.location.pathname;
    switch(pathname){
        case "/om-os.html":
            document.getElementById("about").classList.add("current");
            break;
        case "/produkter.html":
            document.getElementById("products").classList.add("current");
            break;
        case "/lokationer.html":
            document.getElementById("locations").classList.add("current");
            break;
        case "/faq.html":
            document.getElementById("faq").classList.add("current");
            break;
        case "/kontakt.html":
            document.getElementById("contact").classList.add("current");
            break;
        default:
            break;
    }
}

var coll = Array.from(document.getElementsByClassName("faq"));
coll.forEach(i => {
    i.addEventListener("click",function(){
        this.classList.toggle("active")
    });
})