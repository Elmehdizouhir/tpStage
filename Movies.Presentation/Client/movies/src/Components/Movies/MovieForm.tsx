import { ChangeEvent, useEffect, useState } from "react";
import { NavLink, useNavigate, useParams } from "react-router-dom";
import { MovieDto } from "../../Modules/MovieDto";
import ApiConnector from "../../api/ApiConnector";
import { Button, Form, Segment } from "semantic-ui-react";

export default function MovieForm() {
    const { id } = useParams();
    const navigate = useNavigate();
    const [movie, setMovie] = useState<MovieDto>({
        Id: undefined,
        Title: '',
        Description: '',
        CreateDate: new Date(),
        Category: ''
    });

    useEffect(() => {
        if (id) {
            ApiConnector.getMovieById(id).then(movie => setMovie(movie!));
        }
    }, [id]);

    function handleSubmit() {
        if (!movie.Id) {
            ApiConnector.createMovie(movie).then(() => navigate('/'));
        } else {
            ApiConnector.editMovie(movie).then(() => navigate('/')); // ✅ تعديل اسم الدالة
        }
    }

    function handleInputChange(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) {
        const { name, value } = event.target;
        setMovie({ ...movie, [name]: value });
    }

    return (
        <Segment clearing inverted>
            <Form onSubmit={handleSubmit} autoComplete="off" className="ui inverted form">
                <Form.Input placeholder="Title" name="Title" value={movie.Title} onChange={handleInputChange} />
                <Form.TextArea placeholder="Description" name="Description" value={movie.Description} onChange={handleInputChange} />
                <Form.Input placeholder="Category" name="Category" value={movie.Category} onChange={handleInputChange} />
                <Button floated="right" positive type="submit" content="Submit" />
                <Button as={NavLink} to="/" floated="right" negative type="button" content="Cancel" />
            </Form>
        </Segment>
    );
}
