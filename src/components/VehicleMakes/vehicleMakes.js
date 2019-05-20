import React, { Component } from "react";
import Axios from "axios";

import Table from "../Table/table"

class VehicleMakes extends Component {

    state = {
        data:[]
    }

    getVehicleMakes = () => {
        Axios.get("http://localhost:56920/api/vehicleMakes")
        .then((result) => {
            console.log(result);

            if(result.status === 200 && result.data) {
                this.setState({
                    data:result.data.data
                 })
            }
            console.log(this.state.data);
        })
        .catch(error => {
            console.log("error:",error)
        });  
    }

    deleteVehicleMake = (id) => {
        console.log("delete vehicle make");
        
        Axios.delete("http://localhost:56920/api/vehicleMakes", {
            params: {
                id:`${id}`
            }
        })
        .then((result) => {
            console.log(result);

            this.getVehicleMakes();
        })
        .catch(error => {
            console.log(error)
        });
        console.log("id:",id) 
    }

    componentDidMount() {
        this.getVehicleMakes();
    }

    render() {
        return(
            <div>
                {this.state.data.length === 0 
                ? null
                : <Table content={this.state.data}
                         delete={this.deleteVehicleMake}/>
                }
            </div>
        )
    }
}

export default VehicleMakes;