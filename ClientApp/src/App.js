import React, { useEffect, useState } from "react";
import "./custom.css";
import { getFovRequest, login } from "./Services/FovRequest";

function App() {
  const [user, setUser] = useState("");
  const [pass, setPass] = useState("");

  const handleLogin = async () => {
    try {
      const data = await login(user, pass);
      console.log(data);
    } catch (error) {
      console.error("An error occurred:", error);
    }
  };

  const fetchData = async () => {
    let data = await getFovRequest();
    console.log(data);
  };

  useEffect(() => {
    fetchData();
  }, []);

  return (
    <>
      <input
        value={user}
        onChange={(e) => setUser(e.target.value)}
        placeholder="User"
      />
      <input
        value={pass}
        onChange={(e) => setPass(e.target.value)}
        placeholder="Pass"
      />
      <button onClick={handleLogin}>Login</button>
    </>
  );
}

export default App;
