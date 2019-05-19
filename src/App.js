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

    

updateVehicleMake = () => {
    Axios.put("https://localhost:5001/api/vehicleMakes/f658dc6f-5020-4e8e-1f16-08d6d8a0be", {
    
            name:"blaaaaaaa222"
         
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