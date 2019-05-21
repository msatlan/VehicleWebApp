import React, { Component } from 'react';

import ObjectPropertyView from "./ObjectPropertyView";


class VehicleMakeView extends Component {

    state = {
        readOnly: false
    }

    componentDidMount = () => {
        this.setState({
            readOnly: this.props.location.readOnly
        })
    }

    render() {
        return (
            <div>
                <header>
                    <h3>{this.state.readOnly ? <div>Details</div> : <div>Edit</div>}</h3>
                </header>

                <ObjectPropertyView title="Name"
                                    value={this.props.location.vehicle.name}
                                    readOnly={this.state.readOnly}
                /><br/>
                
                <ObjectPropertyView title="Id"
                                    value={this.props.location.vehicle.id}
                                    readOnly={true}
                /><br/>

                <ObjectPropertyView title="Abbreviation"
                                    value={this.props.location.vehicle.abbreviation}
                                    readOnly={this.state.readOnly}
                /><br/>

                <ObjectPropertyView title="Models"
                                    value={this.props.location.vehicle.models.join(", ")}
                                    readOnly={true}
                /><br/>
            </div>
        );
    }
};

export default VehicleMakeView;