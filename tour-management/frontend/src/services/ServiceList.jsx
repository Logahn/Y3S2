import React from "react";
import ServiceCard from "./ServiceCard";
import { Col } from "reactstrap";

import weatherImg from "../assets/images/weather.png";
import guideImg from "../assets/images/guide.png";
import customizationImg from "../assets/images/customization.png";

const servicesData = [
  {
    imgUrl: weatherImg,
    title: "Calculate Weather",
    desc: "Check out accurate weather forecast of your destination before you book your tour.",
  },

  {
    imgUrl: guideImg,
    title: "Best Tour Guide",
    desc: "We offer the best tour guide there is.",
  },

  {
    imgUrl: customizationImg,
    title: "Customization",
    desc: "Make your tour as bespoke as you wish.",
  },
];

const ServiceList = () => {
  return (
    <>
      {servicesData.map((item, index) => (
        <Col lg="3" key={index}>
          <ServiceCard item={item} />
        </Col>
      ))}
    </>
  );
};

export default ServiceList;
