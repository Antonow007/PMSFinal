SELECT c.name_, ct.brand_name, ct.model_name, p.name_, r.reservation_end 
                FROM Car AS car
                JOIN Customer AS c ON c.id = car.id_customer
                JOIN Car_Type AS ct ON ct.id = car.brand
                JOIN Reservation AS r ON r.car_id = car.id
                JOIN Parking AS p ON p.id = r.parking_id
                WHERE car.license_plate = 'CA0007TM';Q