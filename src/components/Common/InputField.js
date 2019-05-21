import React from 'react';

const InputField = (props) => {
    return (
        <div>
            {props.title}: <input defaultValue={props.value}
                                  name={props.name}
                                  style={{
                                          width:"400px",
                                          position: "absolute",
                                          left: "200px"
                                        }}
                                  readOnly={props.readOnly}
                                  onChange={props.text}
                            />
        </div>
     );
    
}

export default InputField;