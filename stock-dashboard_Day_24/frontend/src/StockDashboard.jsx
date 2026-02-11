import React from "react";
import { io } from "socket.io-client";

class StockDashboard extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      symbol: "",
      price: "",
      previousSearches: []
    };

    this.socket = io("http://localhost:5000");
    this.uncontrolledRef = React.createRef();
  }

  componentDidMount() {
    this.socket.on("stockUpdate", (data) => {
      this.setState({ price: data.price });
    });
  }

  componentDidUpdate(prevProps, prevState) {
    if (prevState.symbol !== this.state.symbol) {
      console.log("Symbol updated:", this.state.symbol);
    }
  }

  handleChange = (e) => {
    this.setState({ symbol: e.target.value });
  };

  handleSearch = async () => {
    const response = await fetch(
      `http://localhost:5000/stock/${this.state.symbol}`
    );
    const data = await response.json();

    this.setState((prevState) => ({
      price: data.price,
      previousSearches: [...prevState.previousSearches, data.symbol]
    }));

    this.uncontrolledRef.current.value += data.symbol + " ";
  };

  render() {
    return (
      <div className="container mt-5">
        <h1 className="text-center text-primary">
          📈 Stock Market Dashboard
        </h1>

        <div className="card p-4 shadow">
          <input
            type="text"
            className="form-control mb-3"
            placeholder="Enter Stock Symbol"
            value={this.state.symbol}
            onChange={this.handleChange}
          />

          <button
            className="btn btn-success mb-3"
            onClick={this.handleSearch}
          >
            Search
          </button>

          <h4>Current Price: ${this.state.price}</h4>

          <h5 className="mt-3">Previous Searches:</h5>
          <textarea
            ref={this.uncontrolledRef}
            className="form-control"
            readOnly
          />
        </div>
      </div>
    );
  }
}

export default StockDashboard;
