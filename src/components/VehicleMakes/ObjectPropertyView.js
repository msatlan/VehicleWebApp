import React, { Component } from 'react';

class ObjectPropertyView extends Component {
    
    render() {
        return (
            <div>
                {this.props.title}: <input defaultValue={this.props.value}
                                           style={{
                                           width:"400px",
                                           position: "absolute",
                                           left: "200px"
                                           }}
                                           readOnly={this.props.readOnly}
                                    />
            </div>
        );
    }
}

export default ObjectPropertyView;