import React from "react";

function Welcome(props) {
    return (
        <div style={{ background: props.backgroundColor, width: '400px' }} >
            <h2>
                Hello {props.name}
            </h2>
            <h4>
                Age: {props.age}
            </h4>
        </div>
    )
}
export default Welcome