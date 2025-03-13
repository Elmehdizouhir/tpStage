import { createBrowserRouter, RouteObject } from "react-router-dom";
import MovieForm from "../Components/Movies/MovieForm";
import MovieTable from "../Components/Movies/MovieTable";
import App from "../App";


export const routes : RouteObject[] = [
    {
        path: '/',
        element : <App />,
        children : [
            {
                path : 'createMovie', element : <MovieForm key='create' />
            },
            {
                path : 'editMovie', element : <MovieForm key='edit' />
            },
            {
                path : '*', element : <MovieTable  />
            }
        ]
    }
]
export const router = createBrowserRouter(routes);