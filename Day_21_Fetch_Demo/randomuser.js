function getUser() {
    fetch("https://randomuser.me/api/")
        .then(response => response.json())
        .then(data => {
            let user = data.results[0];

            let name = user.name.first + " " + user.name.last;
            let email = user.email;
            let picture = user.picture.large;

            document.getElementById("userInfo").innerHTML = `
                <h3>${name}</h3>
                <p>Email: ${email}</p>
                <img src="${picture}" alt="User Picture">
            `;
        })
        .catch(error => {
            console.error("Error fetching user:", error);
        });
}