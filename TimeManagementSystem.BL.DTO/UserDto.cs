namespace TimeManagementSystem.BL.DTO
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string TeamId { get; set; }
        public TeamDto Team { get; set; }
        public string Role { get; set; }
    }
}
