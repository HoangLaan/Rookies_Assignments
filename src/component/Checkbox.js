import React from "react";
import { useState } from "react";

const datas = [
    {
        id: 1,
        name: 'All'
    },
    {
        id: 2,
        name: 'Coding'
    },
    {
        id: 3,
        name: 'Music'
    },
    {
        id: 4,
        name: 'Reading books'
    }
]


function Checkbox() {
    const [checked, setCheck] = useState([])

    const handleCheck = (id, name) => {
        setCheck(prev => {
            const isChecked = checked.includes(id)
            if (name == 'All') {
                if (isChecked)
                    return []
                return [1, 2, 3, 4]
            }
            if (isChecked) {
                return checked.filter(item => item !== id)
            } else {
                return [...prev, id]
            }
        })
    }

    const selectedStatus = datas.reduce((acc, data) => {
        if (data.id !== 1) {
            acc[data.name] = checked.includes(data.id);
        }
        return acc;
    }, {});

    return (
        <div className="App">
            <p>Choose your interest</p>
            {datas.map(data => (
                <div key={data.id} >
                    <input
                        type='checkbox'
                        checked={checked.includes(data.id)}
                        onChange={() => handleCheck(data.id, data.name)}
                    />
                    {data.name}
                </div>
            ))}
            <p>You selected</p>
            <pre>{JSON.stringify(selectedStatus)}</pre>
        </div>
    );
}

export default Checkbox