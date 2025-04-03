const Navbar = ({ username, onLogout }) => (
    <nav className="p-4 bg-gray-800 text-white flex justify-between">
      <span>Hi, {username}</span>
      <button onClick={onLogout} className="bg-red-500 px-4 py-2 rounded">Logout</button>
    </nav>
  );
  
  export default Navbar;
  