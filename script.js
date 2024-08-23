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
    })
    .catch(error => console.error('Error loading header:', error));
}

Array.from(document.getElementsByClassName("observe")).forEach(target => {
    observer.observe(target);
});