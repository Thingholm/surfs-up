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

const dateInput = document.getElementById("date-input");
const calendar = document.getElementById("calendar");
const calendarContainer = document.getElementById("calendar-container");
const monthSelector = document.getElementById("month");
const currentDate = new Date();
let selectedMonth = currentDate.getMonth();
const weekDays = ["ma", "ti", "on", "to", "fr", "lø", "sø"];
const months = ["Januar", "Februar", "Marts", "April", "Maj", "Juni", "Juli", "August", "September", "Oktober", "November", "December"];

dateInput.addEventListener("click", () => {
    calendarContainer.style.display == "none" ? calendarContainer.style.display = "inline-block" : calendarContainer.style.display = "none"
})

function buildCalendar(month, year) {
    monthSelector.innerHTML = months.slice(currentDate.month).map((m, index) => `<option class="month-option" value=${index} ${index == month ? "selected" : ""}>${m}</option>`);
    
    let table = "<table><thead><tr>";

    weekDays.map(wd => table += "<th>" + wd + "</th>")

    table += "</tr></thead><tbody><tr>";

    let firstDay = new Date(year, month).getDay(); 
    firstDay == 0 ? firstDay = 6 : firstDay--;

    const daysInMonth = new Date(year, month + 1, 0).getDate();

    for (let i = 0; i < firstDay; i++) {
        table += "<td></td>";
    }

    for (let i = 1; i <= daysInMonth; i++) {
        if ((firstDay + i - 1) % 7 === 0) {
            table += "</tr><tr>";
        }
        table += `<td class="date" data-date="${i}">${i}</td>`;
    }
    table += "</tr></tbody></table>";

    calendar.innerHTML = table;

    const dates = calendar.querySelectorAll(".date");
    dates.forEach(date => {
        date.addEventListener("click", function() {
            dates.forEach(d => d.classList.remove("selected"));
            this.classList.add("selected")
            dateInput.value = `${this.dataset.date.padStart(2, "0")}-${String(parseInt(month) + 1).padStart(2, "0")}-${year}`
            calendarContainer.style.display = "none"
        })
    })
}

buildCalendar(selectedMonth, currentDate.getFullYear());

monthSelector.addEventListener("change", (event) => {
    selectedMonth = event.target.value;
    buildCalendar(selectedMonth, currentDate.getFullYear());
})