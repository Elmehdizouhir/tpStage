import axios, { AxiosResponse} from "axios";
import { GetMovieResponse } from "../Modules/GetMovieResponse";
import { MovieDto } from "../Modules/MovieDto";
import { GetMovieByIdResponse } from "../Modules/GetMovieByIdResponse";
import API_BASE_URL  from "../../Config";

const ApiConnector = {
    
    getMovies: async (): Promise<MovieDto[]> => {
        
            const response: AxiosResponse<GetMovieResponse> = 
                await axios.get(`${API_BASE_URL}/movies`);
    
            // التأكد من أن البيانات موجودة وليست undefined
            if (!response.data || !Array.isArray(response.data.moviesDto)) {
                console.error("Invalid response format:"/*, response.data*/);
                return []; // إرجاع مصفوفة فارغة بدلًا من undefined
            }
    
            // تحويل البيانات
            const movies = response.data.moviesDto.map(movie => ({
                ...movie,
                CreateDate: new Date(movie.CreateDate) // تحويل التاريخ
            }));
    
            return movies;
        },
    createMovie : async (movie : MovieDto) : Promise<void> => {
       
        await axios.post<number>(`${API_BASE_URL}/movies`, movie)
            
    },
    editMovie : async (movie : MovieDto) : Promise<void> => {
       
         await axios.put<number>(`${API_BASE_URL}/movies/${movie.Id}`, movie)
    },
    deleteMovie : async (movieId : number) : Promise<void> => {

        await axios.delete<number>(`${API_BASE_URL}/movies/${movieId}`)
    },
    getMovieById : async (movieId : string) : Promise<MovieDto  | undefined> => {

         const response = await axios.get<GetMovieByIdResponse>(`${API_BASE_URL}/movies/${movieId}`)
         return  response.data.movieDto; 
    }
 
}
export default ApiConnector;