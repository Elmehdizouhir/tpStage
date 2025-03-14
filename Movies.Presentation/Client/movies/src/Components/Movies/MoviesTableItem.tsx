import { Button } from "semantic-ui-react"
import { MovieDto } from "../../Modules/MovieDto"
import ApiConnector from "../../api/ApiConnector"
import { NavLink } from "react-router-dom"

interface Props {
    movie : MovieDto
}
export default function MovieTableItem({movie} : Props) {

    console.log("movie item", movie)
    return (
        <>
        <tr className="center aligned">
            <td data-label='Id'>{movie.Id}</td>
            <td data-label='Title'>{movie.Title}</td>
            <td data-label='Desciption'>{movie.Description}</td>
            <td data-label='CreateDate'>{movie.CreateDate.toDateString()}</td>
            <td data-label='Category'>{movie.Category}</td>
            <td data-label='Action'>
                <Button as={NavLink} to={`editMovie/${movie.Id}`} type="submit" color="yellow" >
                    edit 
                </Button>
                <Button type="button" negative onClick={async () =>
                    {
                       if (movie.Id !== undefined) {
                        await ApiConnector.deleteMovie(movie.Id);
                        window.location.reload();
                        console.log("deleteMovie");
                       }
                       else{
                        console.log("no delete");
                        
                       }
                    }
                }>
                    delete
                </Button>
            </td>
        </tr>
        </>
    )
}