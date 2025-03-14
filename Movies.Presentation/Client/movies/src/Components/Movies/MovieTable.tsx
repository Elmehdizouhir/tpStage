import { useEffect, useState } from "react";
import { MovieDto } from "../../Modules/MovieDto";
import ApiConnector from "../../api/ApiConnector";
import { Button, Container } from "semantic-ui-react";
import MovieTableItem from "./MoviesTableItem";
import { NavLink } from "react-router-dom";

const MovieTable = () => {
   const [movies, setMovies] = useState<MovieDto[]>([]);
   const fetchData = async () => {
    try {
        const fetchedMovies = await ApiConnector.getMovies();
        console.log("Fetched Movies:", fetchedMovies); // Confirm data from API
        setMovies(fetchedMovies); // Update state    
    } catch (error) {
        console.error("Error fetching movies:", error);
    }
};

console.log("State Movies:", movies); // Confirm data from API  

useEffect(() => {
    fetchData();
}, []); 

    return (
        <>
        <Container className="container-style">
            <table className="ui inverted table">
                <thead style={{ textAlign: 'center' }}>
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
                {movies && movies.length > 0 ? (
                        movies.map((movie, index) => (
                            <MovieTableItem key={index} movie={movie} />
                        ))
                    ) : (
                        <tr>
                            <td colSpan={6} style={{ textAlign: "center" }}>
                                No movies available.
                            </td>
                        </tr>
                    )}
                </tbody>
            </table>
            <Button as={NavLink} to='createMovie' floated="right" type="button" content="create movie" positive />
        </Container>
        </>
    );
};

export default MovieTable;
