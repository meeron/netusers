import client from './http-client'

function randomTimeout() {
  const min = 1500;
  const max = 3000;

  return Math.floor(Math.random() * (max - min + 1)) + min;
}

class Api {

  getUsers() {
    return client.get('users');
  }

  saveUser(user) {
    return client.put('users', user);
  }

  deleteUser(id) {
    return client.delete(`users/${id}`);
  }

  addGroup(group) {
    return new Promise(resolve => {
      const groups = JSON.parse(localStorage.getItem("groups") || "[]");
      groups.push(group);
      localStorage.setItem("groups", JSON.stringify(groups));

      resolve(group);
    });
  }

  getGroups() {
    return new Promise(resolve => {
      setTimeout(() => resolve(JSON.parse(localStorage.getItem("groups") || "[]")), randomTimeout());
    });
  }

  deleteGroup(id) {
    return new Promise(resolve => {
      let groups = JSON.parse(localStorage.getItem("groups"));
      const index = groups.findIndex(grp => grp.id === id);
      if (index === -1) {
        resolve(false);
      } else {
        setTimeout(() => {
          groups.splice(index, 1);
          localStorage.setItem("groups", JSON.stringify(groups));
          resolve(true);
        }, randomTimeout());
      }
    });
  }
}

const api = new Api();

export default api;
