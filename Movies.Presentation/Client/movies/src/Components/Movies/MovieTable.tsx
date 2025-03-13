import { useEffect, useState } from "react"
import { MovieDto } from "../../Modules/MovieDto"
import ApiConnector from "../../api/ApiConnector";
import { Button, Container } from "semantic-ui-react";
import MovieTableItem from "./MoviesTableItem";
import { NavLink } from "react-router-dom";



export default function MovieTable() {
   const [movies, setMovies] = useState<MovieDto[]>([]);
   useEffect(() =>{
    const fatchedData = async () =>{
        const fetchedMovies = await ApiConnector.getMovies();
        console.log(fetchedMovies);
        setMovies(fetchedMovies);
    }
    fatchedData();
   }, [])


    return (
        <>
        <Container className="container-style">
            <table className="ui inverted table">
                <thead style={{textAlign : 'center'}}>
                    <tr>
                        <th>id</th>
                        <th>Title</th>
                        <th>Description</th>
                        <th>Date</th>
                        <th> Category</th>
                        <th>Action</th>
                    </tr>

                </thead>
                <tbody>
                    {movies.map((movie, index) =>(
                        <MovieTableItem key={index} movie= {movie} />

                    ))}
{/* {movies.length !== 0 && (movies.map((movie, index) =>(
                        <MovieTableItem key={index} movie= {movie} />

                    )))} */}
                </tbody>
            </table>
            <Button as={NavLink} to='createMovie' floated="right" type="button" content="create movie" positive />

        </Container>
        </>
    )
    
}