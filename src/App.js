import React, { Component } from "react";
import { BrowserRouter } from "react-router-dom";

// Components
import Routes from "./routes"


class App extends Component {

/*
    postVehicleMake = () => {
        Axios.post("https://localhost:5001/api/vehicleMakes", {
            name:"vijekl iz reacta"
        })
        .then((result) => {
            console.log(result);
        })
        .catch(error => {
            console.log(error)
        });
    }

    


*/
    render(){
        return(
            <BrowserRouter>
                <Routes/>
            </BrowserRouter>
        )
    }
}

export default App;