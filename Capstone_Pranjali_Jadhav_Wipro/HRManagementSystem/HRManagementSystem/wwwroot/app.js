const apiUrl = "/api/Employee";
let editingId = 0;
function loadDepartments() {
    fetch("/api/Department")
        .then(res => res.json())
        .then(data => {
            const dropdown = document.getElementById("departmentId");
            dropdown.innerHTML = "";

            data.forEach(dep => {
                dropdown.innerHTML += `
                    <option value="${dep.departmentId}">
                        ${dep.departmentName}
                    </option>`;
            });
        });
}


document.getElementById("empForm")
    .addEventListener("submit", function (e) {

        e.preventDefault();

        const employee = {
            employeeId: editingId,
            name: document.getElementById("name").value,
            email: document.getElementById("email").value,
            departmentId: parseInt(document.getElementById("departmentId").value),
            leaveBalance: parseInt(document.getElementById("leaveBalance").value)
        };

        // ADD
        if (editingId === 0) {

            fetch("/api/Employee", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(employee)
            })
                .then(() => {
                    alert("Employee Added Successfully!");
                    getEmployees();
                });
        }

        // UPDATE
        else {

            fetch("/api/Employee", {
                method: "PUT",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(employee)
            })
                .then(() => {
                    alert("Employee Updated Successfully!");
                    editingId = 0;
                    document.getElementById("empForm").reset();
                    document.querySelector("button[type='submit']").innerText = "Add";
                    getEmployees();
                });
        }
    });

function getEmployees() {
    fetch(apiUrl)
        .then(response => response.json())
        .then(data => {
            const table = document.querySelector("#empTable tbody");
            table.innerHTML = "";

            data.forEach(emp => {
                table.innerHTML += `
<tr>
    <td>${emp.employeeId}</td>
    <td>${emp.name}</td>
    <td>${emp.email}</td>
    <td>${emp.department ? emp.department.departmentName : ''}</td>
    <td>${emp.leaveBalance}</td>
    <td>
        <button class="btn btn-primary btn-sm"
            onclick="editEmployee(${emp.employeeId},
            '${emp.name}',
            '${emp.email}',
            ${emp.department.departmentId},
            ${emp.leaveBalance})">
            Edit
        </button>

        <button class="btn btn-danger btn-sm"
            onclick="deleteEmployee(${emp.employeeId})">
            Delete
        </button>
    </td>
</tr>
`;
            });
        });
}
function deleteEmployee(id) {

    if (!confirm("Are you sure you want to delete this employee?"))
        return;

    fetch(`/api/Employee/${id}`, {
        method: "DELETE"
    })
        .then(response => {
            if (response.ok) {
                alert("Employee deleted successfully!");
                getEmployees();   // reload table
            } else {
                alert("Delete failed!");
            }
        });
}

function editEmployee(id, name, email, departmentId, leaveBalance) {

    editingId = id;

    document.getElementById("name").value = name;
    document.getElementById("email").value = email;
    document.getElementById("departmentId").value = departmentId;
    document.getElementById("leaveBalance").value = leaveBalance;

    document.querySelector("button[type='submit']").innerText = "Update";
}

function loadLeaveEmployees() {
    fetch("/api/Employee")
        .then(res => res.json())
        .then(data => {
            const dropdown = document.getElementById("leaveEmployeeId");
            dropdown.innerHTML = "";

            data.forEach(emp => {
                dropdown.innerHTML +=
                    `<option value="${emp.employeeId}">
                    ${emp.name}
                </option>`;
            });
        });
}
document.getElementById("leaveForm")
    .addEventListener("submit", function (e) {
        e.preventDefault();

        const leave = {
            employeeId: parseInt(document.getElementById("leaveEmployeeId").value),
            fromDate: document.getElementById("fromDate").value,
            toDate: document.getElementById("toDate").value
        };

        fetch("/api/LeaveRequest", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(leave)
        })
            .then(() => {
                alert("Leave Request Submitted!");
                getLeaveRequests();
                document.getElementById("leaveForm").reset();
            });
    });
            
    
function getLeaveRequests() {
    fetch("https://localhost:7120/api/LeaveRequest")
        .then(res => res.json())
        .then(data => {

            const tbody = document.querySelector("#LeaveTable tbody");

            tbody.innerHTML = "";

            data.forEach(req => {
                tbody.innerHTML += `
                <tr>
                    <td>${req.leaveRequestId}</td>
                    <td>${req.employee ? req.employee.name : ""}</td>
                    <td>${req.fromDate ? req.fromDate.split("T")[0] : ""}</td>
                    <td>${req.toDate ? req.toDate.split("T")[0] : ""}</td>
                    <td>${req.status ?? ""}</td>
                    <td>${req.daysRequested}</td>
                    <td>
                        <button onclick="approveLeave(${req.leaveRequestId})">Approve</button>
                        <button onclick="rejectLeave(${req.leaveRequestId})">Reject</button>
                    </td>
                </tr>
                `;
            });
        });
}
function approveLeave(id) {
    fetch(`/api/LeaveRequest/approve/${id}`, { method: "PUT" })
        .then(() => {
            alert("Approved");
            getLeaveRequests();
            getEmployees();
        });
}

function rejectLeave(id) {
    fetch(`/api/LeaveRequest/reject/${id}`, { method: "PUT" })
        .then(() => {
            alert("Rejected");
            getLeaveRequests();
        });
}
document.addEventListener("DOMContentLoaded", function () {
    loadDepartments();
    getEmployees();
    loadLeaveEmployees();
    getLeaveRequests();
});