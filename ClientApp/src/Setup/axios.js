import axios from "axios";
const instance = axios.create({
  baseURL: "http://localhost:5235",
});

instance.defaults.withCredentials = true;
/* instance.defaults.headers.common['Authorization'] = AUTH_TOKEN; */

instance.interceptors.request.use(
  function (config) {
    return config;
  },
  function (error) {
    return Promise.reject(error);
  }
);

instance.interceptors.response.use(
  function (response) {
    return response.data;
  },

  function (error) {
    const status = (error && error.response && error.response?.status) || 500;
    switch (status) {
      // authentication (token related issues)
      case 401: {
        return Promise.reject(error);
      }

      // forbidden (permission related issues)
      case 403: {
        return Promise.reject(error);
      }

      // bad request
      case 400: {
        return Promise.reject(error);
      }

      // not found
      case 404: {
        return Promise.reject(error);
      }

      // conflict
      case 409: {
        return Promise.reject(error);
      }

      // unprocessable
      case 422: {
        return Promise.reject(error);
      }

      // generic api error (server related) unexpected
      default: {
        return Promise.reject(error);
      }
    }
  }
);

export default instance;
