import axios, { AxiosError } from "axios";
import React, {
  DO_NOT_USE_OR_YOU_WILL_BE_FIRED_CALLBACK_REF_RETURN_VALUES,
  useEffect,
  useState,
} from "react";

type Request = {
  endpoint: string;
};

const useFetch = <T>(request: Request) => {
  const [data, setData] = useState<T>();
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [error, setError] = useState<AxiosError | null>(null);

  const options = {
    method: "GET",
    url: `https://dummyjson.com/${request.endpoint}`,
  };

  const fecthData = async () => {
    setIsLoading(true);
    try {
      const response = await axios.request(options);
      setData(response.data);
    } catch (error) {
      console.log(error);
      setError(error as AxiosError);
    } finally {
      setIsLoading(false);
    }
  };

  useEffect(() => {
    fecthData();
  }, []);

  return { data, isLoading, error };
};

export default useFetch;
