const scrollToForm = () => {
  document.getElementById("form").scrollIntoView();
};

let requests = [];

document.getElementById("requestForm").addEventListener("submit", async (e) => {
  e.preventDefault();

  const name = document.getElementById("name").value;
  const email = document.getElementById("email").value;
  const service = document.getElementById("service").value;
  const desc = document.getElementById("desc").value;

  if (!name || !email || !service || !desc) {
    document.getElementById("msg").innerText = "All fields required";
    return;
  }

  requests = [...requests, { name, service }];
  render();

  e.target.reset();
});

const render = () => {
  const list = document.getElementById("list");
  list.innerHTML = "";
  requests.forEach(r => {
    const li = document.createElement("li");
    li.innerText = `${r.name} - ${r.service}`;
    list.appendChild(li);
  });
};

const loadData = async () => {
  try {
    const res = await fetch("data.json");
    const data = await res.json();
    console.log(data);
  } catch {
    console.log("Fetch error");
  }
};

loadData();
