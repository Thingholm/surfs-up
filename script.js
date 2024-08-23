const interSectionObserverOptions = {
    root: document.querySelector("body"),
    rootMargin: "0px",
    threshold: 0.2
}

const handleIntersect = (entries, observer) => {
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

