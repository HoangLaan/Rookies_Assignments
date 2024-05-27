import logo from './logo.svg';
import './App.css';
import { useState, useEffect } from 'react';
import Welcome from './component/Welcome';
import Counter from './component/Counter';
import Checkbox from './component/Checkbox';
import Pokemon from './component/Pokemon';
import Register from './component/RegisterForm';

const profiles = [
  {
    id: 1,
    name: 'Hoang Lan',
    age: 22,
    backgroundColor: 'red'
  },
  {
    id: 2,
    name: 'Son tung MTP',
    age: 30,
    backgroundColor: 'yellow'
  },
  {
    id: 3,
    name: 'Ronaldo',
    age: 38,
    backgroundColor: 'green'
  },
]

function App() {
  const [selectedOption, setSelectedOption] = useState('register');

  const handleSelectChange = (event) => {
    setSelectedOption(event.target.value);
  };

  let renderComponent;
  switch (selectedOption) {
    case "welcome":
      renderComponent =
        <div>
          {profiles.map(profile => (
            <Welcome
              key={profile.id}
              name={profile.name}
              age={profile.age}
              backgroundColor={profile.backgroundColor}
            />
          ))}
        </div>
      break;
    case "counter":
      renderComponent = <Counter />
      break;
    case "checkbox":
      renderComponent = <Checkbox />
      break;
    case "pokemon":
      renderComponent = <Pokemon />
      break;
    case "register":
      renderComponent = <Register />
      break;
    default: renderComponent = null;
  }

  return (
    <div className="App">
      <h1>Homework #3</h1>
      <select
        value={selectedOption}
        onChange={handleSelectChange}
        aria-label='label-for-select'
      >
        <option value="">Select an option</option>
        <option value="welcome">Welcome</option>
        <option value="counter">Counter</option>
        <option value="checkbox">Check boxes</option>
        <option value="pokemon">Pokemon</option>
        <option value="register">Register</option>
      </select>
      {selectedOption && <p>Option selected: {selectedOption}</p>}
      {renderComponent}
    </div>
  )
}


export default App;
