import express from "express";
import { verifyAdmin, verifyUser } from "../utils/verifyToken.js";
import {
  createBooking,
  getAllBooking,
  getBooking,
} from "../controllers/bookingController.js";

const router = express.Router();

//* Create new booking
router.post("/", verifyUser, createBooking);

//* Get single booking
router.get("/:id", verifyUser, getBooking);

//* Get all bookings
router.get("/", verifyAdmin, getAllBooking);
export default router;
