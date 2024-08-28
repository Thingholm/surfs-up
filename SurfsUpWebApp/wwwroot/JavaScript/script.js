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