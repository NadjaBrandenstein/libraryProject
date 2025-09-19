
import './App.css'
import {finalUrl} from "./baseUrl.ts";

function App() {
    

  return (
    <>
        <h1>Library Project</h1>
        <button onClick={() => {
            fetch(finalUrl).then(reponse => {
                console.log(reponse);
            }).catch(e => {
                console.error(e);
            })
        }}>Click me</button>
    </>
  )
}

export default App
