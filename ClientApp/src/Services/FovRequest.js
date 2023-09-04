import axios from "../Setup/axios";

export const login = async (supplierCode, pass) => {
  return await axios.post("https://localhost:7177/api/Supplier/Login", {
    supplierCode: supplierCode,
    pass: pass,
  });
};
export const getFovRequest = async () => {
  return await axios.get("https://localhost:7177/api/FovRequest");
};
