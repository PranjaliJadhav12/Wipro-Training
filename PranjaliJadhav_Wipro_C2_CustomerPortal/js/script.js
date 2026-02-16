document.getElementById("contactForm").addEventListener("submit", function(event) {
    event.preventDefault();

    let name = document.getElementById("name").value;
    let email = document.getElementById("email").value;

    if(name === "" || email === "") {
        alert("Please fill all fields");
    } else {
        alert("Form submitted successfully!");
    }
});
