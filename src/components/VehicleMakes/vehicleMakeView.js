import React, { Component } from 'react';
import Axios from "axios";

import InputField from "./InputField";


class VehicleMakeView extends Component {

    state = {
        readOnly: false,
        object: { },
    }

    componentDidMount = () => {
        this.setState({
            readOnly: this.props.location.readOnly,
            object: this.props.location.vehicle
        })
    }

    updateVehicleMake = (id) => {
        Axios.put(`http://localhost:56920/api/vehicleMakes/${id}`, {
                name: this.state.object.name,
                abbreviation: this.state.object.abbreviation 
        })
        .then((result) => {
            console.log(result);
        })
        .catch(error => {
            console.log(error)
        });
    }

    getText = (event) => {
        this.setState({
            object: {
                ...this.state.object,
                [event.target.name] : event.target.value
            }
        })
    }

    render() {
        return (
            <div>
                <header>
                    <h3>{this.state.readOnly ? <div>Details</div> : <div>Edit</div>}</h3>
                </header>

                <InputField title="Name"
                            name="name"
                            value={this.state.object.name}
                            readOnly={this.state.readOnly}
                            text={this.getText}
                /><br/>
                
                <InputField title="Id"
                            value={this.state.object.id}
                            readOnly={true}
                /><br/>

                <InputField title="Abbreviation"
                            name="abbreviation"
                            value={this.state.object.abbreviation}
                            readOnly={this.state.readOnly}
                            text={this.getText}
                /><br/>

                <InputField title="Models"
                            value={this.state.object.models}
                            readOnly={true}
                /><br/>

                {this.state.readOnly ? null : <button onClick={() => this.updateVehicleMake(this.state.object.id)}>Save</button>}
            </div>
        );
    }
};

export default VehicleMakeView;