import axios, { AxiosResponse} from "axios";
import { GetMovieResponse } from "../Modules/GetMovieResponse";
import { MovieDto } from "../Modules/MovieDto";
import { GetMovieByIdResponse } from "../Modules/GetMovieByIdResponse";
import API_BASE_URL  from "../../Config";

const ApiConnector = {
    
    getMovies: async (): Promise<MovieDto[]> => {
        try {
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
        } catch (error) {
            console.error("Error while fetching movies", error);
            return []; // إرجاع مصفوفة فارغة عند حدوث خطأ
        }
    }
    ,
    createMovie : async (movie : MovieDto) : Promise<void> => {
        try {
            await axios.post<number>(`${API_BASE_URL}/movies`, movie)
        } catch (error) {
            console.log(error);
            throw error;
        }
    },
    editMovie : async (movie : MovieDto) : Promise<void> => {
        try {
            await axios.put<number>(`${API_BASE_URL}/movies`, movie)
        } catch (error) {
            console.log(error);
            throw error;
        }
    },
    deleteMovie : async (movieId : number) : Promise<void> => {
        try {
            await axios.delete<number>(`${API_BASE_URL}/movies/${movieId}`)
        } catch (error) {
            console.log(error);
            throw error;
        }
    },
    getMovieById : async (movieId : string) : Promise<MovieDto  | undefined> => {
        try {
            const response = await axios.get<GetMovieByIdResponse>(`${API_BASE_URL}/movies/${movieId}`)
             return  response.data.movieDto;
            
        } catch (error) {
            console.log(error);
            throw error;
        }
         





        
    }
 
}
export default ApiConnector;