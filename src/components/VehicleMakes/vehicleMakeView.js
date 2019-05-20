import React, { Component } from 'react';

class VehicleMakeView extends Component {

    render() {
        return (
            <div>
                <header>
                    <h3>NAME: {this.props.location.vehicle.name}</h3>
                </header>
                <div>
                    ID: {this.props.location.vehicle.id}<br/>
                    ABBREVIATION: {this.props.location.vehicle.abbreviation}<br/>
                    MODELS: {this.props.location.vehicle.models.join(", ")}<br/>
                </div>
            </div>
        );
    }
};

export default VehicleMakeView;