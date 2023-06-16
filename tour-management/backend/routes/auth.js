import express from "express";
import { login, register } from "./../controllers/authController.js";

const router = express.Router();

//* Register New User
router.post("/register", register);

//* User Login
router.post("/login", login);

export default router;
