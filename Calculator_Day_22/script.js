function appendValue(value) {
  document.getElementById("result").value += value;
}

function clearResult() {
  document.getElementById("result").value = "";
}

function calculate() {
  let expresions = document.getElementById("result").value;
  let output = eval(expresions);
  document.getElementById("result").value = output;
}