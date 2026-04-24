import { useState, useEffect } from "react";
import axios from "axios";

function App() {
  const [villas, setVillas] = useState([]);
  const [name, setName] = useState("");
  const [editId, setEditId] = useState(null);

  const API_URL = "http://localhost:5019/api/VillaAPI";

  const fetchVillas = async () => {
    const res = await axios.get(API_URL);
    setVillas(res.data);
  };

  useEffect(() => {
    fetchVillas();
  }, []);

  const addOrUpdateVilla = async () => {
    if (!name) return;

    if (editId) {
      await axios.put(`${API_URL}/${editId}`, {
        id: editId,
        name: name,
      });
      setEditId(null);
    } else {
      await axios.post(API_URL, {
        name: name,
      });
    }

    setName("");
    fetchVillas();
  };

  const deleteVilla = async (id) => {
    await axios.delete(`${API_URL}/${id}`);
    fetchVillas();
  };

  const editVilla = (villa) => {
    setName(villa.name);
    setEditId(villa.id);
  };

  return (
    <div style={{ padding: "20px" }}>
      <h2>Villa Management</h2>

      <h3>{editId ? "Edit Villa" : "Add Villa"}</h3>

      <input
        placeholder="Villa Name"
        value={name}
        onChange={(e) => setName(e.target.value)}
      />

      <button onClick={addOrUpdateVilla}>
        {editId ? "Update" : "Add"}
      </button>

      <hr />

      <h3>Villa List</h3>

      <ul>
        {villas.map((v) => (
          <li key={v.id}>
            {v.name}
            <button onClick={() => editVilla(v)}>Edit</button>
            <button onClick={() => deleteVilla(v.id)}>Delete</button>
          </li>
        ))}
      </ul>
    </div>
  );
}

export default App;