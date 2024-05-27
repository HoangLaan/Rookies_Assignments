import { useState, useEffect } from "react"
import "../App.css"

function Register() {
    const [values, setValues] = useState({
        userName: "", email: "", gender: "",
        password: "", rePassword: "", checkbox: ""
    })

    const [errors, setErrors] = useState({});
    const [isFormValid, setIsFormValid] = useState(false);

    const validate = () => {
        let tempErrors = {};
        let valid = true;
        // User name
        if (!values.userName) {
            tempErrors.userName = "Username is required";
            valid = false;
        } else if (values.userName.length < 4) {
            tempErrors.userName = "Username must be at least 4 characters";
            valid = false;
        } else if (!/^[a-zA-Z0-9]+$/.test(values.userName)) {
            tempErrors.userName = "Username can only contain letters and numbers";
            valid = false;
        }
        // Email
        if (!values.email) {
            tempErrors.email = "Email is required";
            valid = false;
        } else if (!/\S+@\S+\.\S+/.test(values.email)) {
            tempErrors.email = "Email is not valid";
            valid = false;
        }
        // Gender
        if (!values.gender) {
            tempErrors.gender = "Gender is required";
            valid = false;
        }
        // Password
        if (!values.password) {
            tempErrors.password = "Password is required";
            valid = false;
        } else if (values.password.length < 8) {
            tempErrors.password = "Password must be at least 8 characters";
            valid = false;
        }
        // Retype Password
        if (!values.rePassword) {
            tempErrors.rePassword = "Retype password is required";
            valid = false;
        } else if (values.rePassword !== values.password) {
            tempErrors.rePassword = "Confirmed password do not match";
            valid = false;
        }
        // Checkbox
        if (!values.checkbox) {
            tempErrors.checkbox = "You must agree to the terms";
            valid = false;
        }

        setErrors(tempErrors);
        setIsFormValid(valid);
    };

    const handleChange = (e) => {
        const { name, value, type, checked } = e.target;
        setValues({
            ...values,
            [name]: type === 'checkbox' ? checked : value
        });
        console.log(name, 'name');
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        validate();
    };

    console.log(values)
    return (
        <>
            <form onSubmit={handleSubmit}>
                <div className="margin-input">
                    <p style={{ display: 'inline-block', paddingRight: '10px', margin: '0px', fontWeight: 'bold' }}>User name: </p>
                    <input
                        value={values.userName}
                        placeholder="User Name"
                        name="userNam1e"
                        onChange={handleChange}

                    />
                    {errors.userName && <p className="validation-error">{errors.userName}</p>}
                </div>

                <div className="margin-input">
                    <p style={{ display: 'inline-block', paddingRight: '48px', margin: '0px', fontWeight: 'bold' }}>Email: </p>
                    <input
                        value={values.email}
                        placeholder="Email"
                        name="email"
                        onChange={handleChange}

                    />
                    {errors.email && <p className="validation-error">{errors.email}</p>}</div>

                <div className="margin-input">
                    <p style={{ display: 'inline-block', paddingRight: '34px', margin: '0px', fontWeight: 'bold' }}>Gender: </p>
                    <select
                        name="gender"
                        value={values.gender}
                        onChange={handleChange}
                    >
                        <option value="">Choose</option>
                        <option value="male">Male</option>
                        <option value="female">Female</option>
                    </select>
                    {errors.gender && <p className="validation-error">{errors.gender}</p>}
                </div>
                <div className="margin-input">
                    <p style={{ display: 'inline-block', paddingRight: '18px', margin: '0px', fontWeight: 'bold' }}>Password: </p>
                    <input
                        value={values.password}
                        placeholder="Password"
                        name="password"
                        type="password"
                        onChange={handleChange}
                    />
                    {errors.password && <p className="validation-error">{errors.password}</p>}
                </div>
                <div className="margin-input">
                    <p style={{ display: 'inline-block', paddingRight: '26px', margin: '0px', fontWeight: 'bold' }}>Confirm: </p>
                    <input
                        value={values.rePassword}
                        placeholder="Retype password"
                        name="rePassword"
                        type="password"
                        onChange={handleChange}
                    />
                    {errors.rePassword && <p className="validation-error">{errors.rePassword}</p>}
                </div>

                <div className="margin-input">
                    <input
                        type="checkbox"
                        checked={values.checkbox}
                        name="checkbox"
                        onChange={handleChange}
                        style={{ marginRight: '10px' }}
                    />
                    <p style={{ display: 'inline-block', margin: '0px', }}>I have read the agreement</p>
                    {errors.checkbox && <p className="validation-error">{errors.checkbox}</p>}
                </div>

                <button type="submit" className="button-submit">Submit</button>
                <button disabled={!isFormValid} className="button-register" >Register</button>
            </form>

        </>
    );
}

export default Register