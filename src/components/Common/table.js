import React, { Component } from "react";
import { Link } from "react-router-dom";

class Table extends Component {

    delete = (id) => {
        this.props.delete(id);
    } 

    render() {
        return(
            <table border="1" cellPadding="10" cellSpacing="1">
    
                <thead>
                     <tr>
                        <td colSpan="5">
                            <h3 style={{textAlign:"center"}}>{this.props.content.type.charAt(0).toUpperCase() + this.props.content.type.slice(1)}</h3>
                        </td>
                    </tr>
                    <tr>
                        <td colSpan="5">    
                            <button style={{float: "left", margin: "10px", width: "100px"}}>Create new</button>
                            <div style={{float: "left", margin: "10px", marginLeft:"100px", width: "100px"}}>Search:</div>
                            <input style={{float: "left", margin: "10px", marginLeft:"-55px", width: "200px"}}></input>
                        </td>
                    </tr>
                </thead>
    
                <tfoot>
                    <tr>
                        <td colSpan="5">
                            <div style={{float: "left", margin: "10px", width: "150px"}}>Results per page:</div>
                            <input style={{float: "left", margin: "10px", marginLeft:"-45px", width: "30px"}}></input>
                            <div style={{float: "left", margin: "10px", marginLeft:"150px", width: "60px"}}>Page</div>
                            <button style={{float: "left", margin: "10px", marginLeft:"350px", width: "80px"}}>Previous</button>
                            <button style={{float: "left", margin: "10px", marginLeft:"0px", width: "80px"}}>Next</button>
                        </td>
                    </tr>
                </tfoot>
    
                <tbody> 
                    <tr>
                        <th>Name</th>
                        <th>Id</th>
                        <th>Abbreviation</th>
                        {this.props.content.type === "vehicleMakes" 
                            ? <th>Models</th> 
                            : <th>Make</th>
                        }
                        <th></th>
                    </tr>
    
                    {this.props.content.data.map((object) => (
                    <tr key={object.id}>
                        <td>{object.name}</td>
                        <td>{object.id}</td>
                        <td>{object.abbreviation}</td>

                        {object.models !== null 
                            ? <td>{object.models.join(", ")}</td> 
                            : <td>{object.make}</td>
                        }

                        <td>
                            <Link to={{
                                pathname: `edit/${this.props.content.type}/${object.name}`,
                                object: object,
                                readOnly: false   
                            }}>
                                <button>Edit</button>
                            </Link>

                            <Link to={{
                                pathname: `/details/${this.props.content.type}/${object.name}`,
                                object: object,
                                readOnly: true
                            }}> 
                                <button>Details</button>
                            </Link>
                            
                            <button onClick={() => this.delete(object.id)}>Delete</button>
                        </td>
                    </tr>
                    ))
                    }
                </tbody>
            </table>
        )
    }   
}

export default Table;