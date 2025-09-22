import './App.css'
import {useEffect, useState} from "react";
import {bookClient} from "./baseUrl.ts";
import type {Book, CreateBookDto} from "./generated-ts-client.ts";

function App() {

    const [books, setBooks] = useState<Book[]>([]);
    const [myForm, setMyForm] = useState<CreateBookDto>({
        title: '',
        pages: 1
    });

    useEffect(() => {
        bookClient.getAllBooks().then(r => {
            setBooks(r);
        })
    }, [])

  return (
    <>
        <h1>Library Project</h1>
        <hr/>
        <input value={myForm.title} onChange={e =>
            setMyForm({...myForm, title: e.target.value})} placeholder="Title"/>
        <input value={myForm.pages} onChange={e =>
            setMyForm({...myForm, pages: Number.parseInt(e.target.value)})} type="number" placeholder="Page count"/>

        <button onClick={() => {
            bookClient.createBook(myForm).then(result => {
                console.log("Successfully created");
                setBooks([...books, result]);
            })
        }}>Create new book</button>
        <hr/>

        {
            books.map(t => {
                return <div key = {t.id}>
                    {JSON.stringify(t)}
                </div>
            })
        }
    </>
  )
}

export default App
