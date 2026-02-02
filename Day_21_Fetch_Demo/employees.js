// Fetch employee data from API
fetch("https://dummy.restapiexample.com/api/v1/employees")
  .then(response => response.json())   // Convert response to JSON
  .then(data => {
      console.log("Employee Data:");
      console.log(data.data); // API returns data inside "data" property
  })
  .catch(error => {
      console.error("Error fetching data:", error);
  });