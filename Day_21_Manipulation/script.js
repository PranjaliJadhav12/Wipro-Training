// STEP 2: Access DOM Objects
const eventList = document.getElementById("eventList");
const eventTitle = document.getElementById("eventTitle");
const eventDesc = document.getElementById("eventDesc");
const countSpan = document.getElementById("count");
const registerBtn = document.getElementById("registerBtn");
const unregisterBtn = document.getElementById("unregisterBtn");
const addEventBtn = document.getElementById("addEventBtn");

// STEP 3: Event Data (Objects)
let events = [
    {
        title: "Music Night",
        description: "Enjoy live music performances",
        participants: 0
    },
    {
        title: "Sports Day",
        description: "Outdoor games and competitions",
        participants: 0
    },
    {
        title: "Tech Talk",
        description: "Discussion on latest technologies",
        participants: 0
    }
];

let selectedEventIndex = null;

// STEP 4: Display Events Dynamically
function displayEvents() {
    eventList.innerHTML = "";

    events.forEach((event, index) => {
        const li = document.createElement("li");
        li.textContent = event.title;

        li.addEventListener("click", function () {
            selectEvent(index);
        });

        eventList.appendChild(li);
    });
}

displayEvents();

// STEP 5: Handle Event Selection
function selectEvent(index) {
    selectedEventIndex = index;

    eventTitle.textContent = events[index].title;
    eventDesc.textContent = events[index].description;
    countSpan.textContent = events[index].participants;

    document.querySelectorAll("li").forEach(li => li.classList.remove("selected"));
    eventList.children[index].classList.add("selected");
}

// STEP 6: Register for Event
registerBtn.addEventListener("click", function () {
    if (selectedEventIndex === null) {
        alert("Please select an event");
        return;
    }

    events[selectedEventIndex].participants++;
    countSpan.textContent = events[selectedEventIndex].participants;
});

// STEP 7: Unregister from Event
unregisterBtn.addEventListener("click", function () {
    if (selectedEventIndex === null) {
        alert("Please select an event");
        return;
    }

    if (events[selectedEventIndex].participants > 0) {
        events[selectedEventIndex].participants--;
        countSpan.textContent = events[selectedEventIndex].participants;
    } else {
        alert("No participants to remove");
    }
});

// STEP 8: Add New Event Dynamically
addEventBtn.addEventListener("click", function () {
    const title = prompt("Enter event title");
    const description = prompt("Enter event description");

    // STEP 9: Client-side Validation
    if (!title || !description) {
        alert("Title and description cannot be empty");
        return;
    }

    events.push({
        title: title,
        description: description,
        participants: 0
    });

    displayEvents();
});
