const express = require("express");
const cors = require("cors");
const http = require("http");
const { Server } = require("socket.io");

const app = express();
const server = http.createServer(app);

const io = new Server(server, {
  cors: {
    origin: "http://localhost:5173",
    methods: ["GET", "POST"]
  }
});

app.use(cors());
app.use(express.json());

let stockPrice = 100;

// REST API
app.get("/stock/:symbol", (req, res) => {
  res.json({
    symbol: req.params.symbol.toUpperCase(),
    price: stockPrice
  });
});

// WebSocket connection
io.on("connection", (socket) => {
  console.log("Client connected");

  setInterval(() => {
    stockPrice += (Math.random() - 0.5) * 5;

    socket.emit("stockUpdate", {
      price: stockPrice.toFixed(2)
    });

  }, 2000);
});

server.listen(5000, () => {
  console.log("Server running on http://localhost:5000");
});
