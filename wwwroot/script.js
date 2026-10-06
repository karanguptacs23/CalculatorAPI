const display = document.getElementById("display");
const firstInput = document.getElementById("a");
const secondInput = document.getElementById("b");
const message = document.getElementById("message");
const clearButton = document.getElementById("clear");

async function calculate(operation) {
  const a = firstInput.value;
  const b = secondInput.value;

  message.textContent = "";

  // Square, Square Root aur Absolute ke liye sirf first number chahiye
  if (operation === "square" || operation === "sqrt" || operation === "abs") {
    if (a === "") {
      message.textContent = "Please enter a number.";
      return;
    }
  } else {
    // Baaki operations ke liye dono numbers chahiye
    if (a === "" || b === "") {
      message.textContent = "Please enter both numbers.";
      return;
    }
  }

  // Divide by zero check
  if (operation === "divide" && Number(b) === 0) {
    message.textContent = "Cannot divide by zero.";
    return;
  }

  // Modulus by zero check
  if (operation === "modulus" && Number(b) === 0) {
    message.textContent = "Cannot calculate modulus by zero.";
    return;
  }

  try {
    let url;

    // Single-number operations
    if (operation === "square" || operation === "sqrt" || operation === "abs") {
      url = `/calculator/${operation}?a=${encodeURIComponent(a)}`;
    } else {
      // Two-number operations
      url = `/calculator/${operation}?a=${encodeURIComponent(a)}&b=${encodeURIComponent(b)}`;
    }

    const response = await fetch(url);

    if (!response.ok) {
      throw new Error(`Request failed: ${response.status}`);
    }

    const result = await response.json();

    display.textContent = result;
  } catch (error) {
    message.textContent = "Could not connect to the API.";
  }
}

// Operation buttons
document.querySelectorAll("[data-operation]").forEach((button) => {
  button.addEventListener("click", () => {
    calculate(button.dataset.operation);
  });
});

// Clear button
clearButton.addEventListener("click", () => {
  firstInput.value = "";
  secondInput.value = "";
  display.textContent = "0";
  message.textContent = "";
});